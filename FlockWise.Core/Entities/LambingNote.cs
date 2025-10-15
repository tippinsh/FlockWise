namespace FlockWise.Core.Entities;

public class LambingNote
{
    public Guid Id { get; set; } = SequentialGuidGenerator.NewSequentialGuid();
    public Guid LambingId { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required, StringLength(255)]
    public string Note { get; set; } = string.Empty;
    public DateTimeOffset LastUpdatedUtc { get; set; }

    // Navigation properties
    public LambingRecord? Lambing { get; set; }
    public User User { get; set; } = null!;
}