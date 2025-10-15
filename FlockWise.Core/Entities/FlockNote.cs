namespace FlockWise.Core.Entities;

public class FlockNote
{
    public Guid Id { get; set; } = SequentialGuidGenerator.NewSequentialGuid();
    public Guid FlockId { get; set; }
    [Required]
    public int UserId { get; set; }
    
    [Required, StringLength(255)]
    public string Note { get; set; } = string.Empty;
    public DateTimeOffset UpdatedAtUtc { get; set; }

    // Navigation properties
    public Flock? Flock { get; set; }
    public User User { get; set; } = null!;
}