namespace FlockWise.Core.Entities;

public class Flock
{
    public Guid Id { get; init; } = SequentialGuidGenerator.NewSequentialGuid();
    
    [Required]
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public string? Name { get; set; }
    public Location? Location { get; set; }
    public DateTimeOffset EstablishedDateUtc { get; init; }
    public Breed? Breed { get; set; }
    public ICollection<FlockNote>? Notes { get; set; }
    public Guid? FieldId { get; set; }
    public Field? Field { get; set; }
    
    // Navigation properties
    public ICollection<Sheep> Sheep { get; set; } = [];
}