namespace FlockWise.Infrastructure.Options;

public class DatabaseOptions
{
    public const string SectionName = "Database";
    
    public string Provider { get; set; } = "PostgresSQL";
    public PostgresOptions Postgres { get; set; } = new();
    public SqliteOptions Sqlite { get; set; } = new();
}