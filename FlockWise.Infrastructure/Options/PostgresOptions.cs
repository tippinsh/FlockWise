namespace FlockWise.Infrastructure.Options;

public class PostgresOptions
{
    public const string SectionName = "Database:Postgres";

    public string ConnectionString { get; set; } = string.Empty;
    public int CommandTimeout { get; set; } = 30;
    public bool EnableRetryOnFailure { get; set; } = true;
    public int MaxRetryCount { get; set; } = 3;
}