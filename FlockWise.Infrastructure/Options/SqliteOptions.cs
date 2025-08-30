namespace FlockWise.Infrastructure.Options;

public class SqliteOptions
{
    public const string SectionName = "Database:Sqlite";
    
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabasePath { get; set; } = "flockwise.db";
}