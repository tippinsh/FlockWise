namespace FlockWise.Core.Entities;

public class FlockNote
{
    public Guid Id { get; set; }
    public Guid FlockId { get; set; }
    [Required, StringLength(255)]
    public string Note { get; set; } = string.Empty;
    public DateTimeOffset LastModified { get; set; }
    public Flock? Flock { get; set; }
}