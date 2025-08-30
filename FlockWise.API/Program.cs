var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
var configuration = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
        case "POSTGRESQL":
        case "POSTGRES":
            options.UseNpgsql(postgresOptions.Value.ConnectionString, npgsqlOptions =>
            {
                npgsqlOptions.CommandTimeout(postgresOptions.Value.CommandTimeout);

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

            options.UseSqlite(connectionString);
            break;

        default: throw new ArgumentException($"Unsupported database provider: {databaseOptions.Value.Provider}");
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();