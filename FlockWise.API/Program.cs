var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
var configuration = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FlockWise API", Version = "v1" });
    
    // Add JWT Authentication to Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Add JWT Authentication
var jwtKey = configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not configured");
var key = Encoding.ASCII.GetBytes(jwtKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = configuration["Jwt:Issuer"],
        ValidateAudience = true,
        ValidAudience = configuration["Jwt:Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization();

// Add AutoMapper - scan all assemblies for profiles
builder.Services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());

// Register Unit of Work
services.AddScoped<IUnitOfWork, UnitOfWork>();

// Register Services
services.AddScoped<IUserService, UserService>();
services.AddScoped<IFlockService, FlockService>();
services.AddScoped<ISheepService, SheepService>();
services.AddScoped<ITokenService, TokenService>();

// Register Repositories
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IFlockRepository, FlockRepository>();
services.AddScoped<ISheepRepository, SheepRepository>();

services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.SectionName));
services.Configure<PostgresOptions>(configuration.GetSection(PostgresOptions.SectionName));
services.Configure<SqliteOptions>(configuration.GetSection(SqliteOptions.SectionName));

services.AddDbContext<FlockWiseDbContext>((serviceProvider, options) =>
{
    var databaseOptions = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>();
    var postgresOptions = serviceProvider.GetRequiredService<IOptions<PostgresOptions>>();
    var sqliteOptions = serviceProvider.GetRequiredService<IOptions<SqliteOptions>>();

    switch (databaseOptions.Value.Provider.ToUpperInvariant())
    {
        case "POSTGRESSQL":
        case "POSTGRES":
            options.UseNpgsql(postgresOptions.Value.ConnectionString, npgsqlOptions =>
            {
                npgsqlOptions.CommandTimeout(postgresOptions.Value.CommandTimeout);
                npgsqlOptions.MigrationsAssembly("FlockWise.Infrastructure");

                if (postgresOptions.Value.EnableRetryOnFailure)
                {
                    npgsqlOptions.EnableRetryOnFailure(postgresOptions.Value.MaxRetryCount);
                }
            });
            break;
        case "SQLITE":
            var connectionString = sqliteOptions.Value.ConnectionString;

            // If connection string is empty, build it from the database path
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = $"Data Source={sqliteOptions.Value.DatabasePath}";
            }

            options.UseSqlite(connectionString, sqliteOptions =>
            {
                sqliteOptions.MigrationsAssembly("FlockWise.Infrastructure");
            });
            break;

        default: throw new ArgumentException($"Unsupported database provider: {databaseOptions.Value.Provider}");
    }
});

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<FlockWiseDbContext>();
    await db.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();