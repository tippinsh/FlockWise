namespace FlockWise.Application.Models.Flock;

public class FlockNotesDto
{
    public Guid Id { get; set; }
    public string Note { get; set; } = string.Empty;
    public DateTimeOffset LastModified { get; set; }
}