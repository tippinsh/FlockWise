namespace FlockWise.Core.Entities;

public class Flock
{
    public Guid Id { get; init; } = SequentialGuidGenerator.NewSequentialGuid();
    [Required]
    public int FarmId { get; set; }
    public string? Name { get; set; }
    public Location? Location { get; set; }
    public DateTimeOffset EstablishedDateUtc { get; init; }
    public Breed? Breed { get; set; }
    public ICollection<FlockNote>? Notes { get; set; }
    public Guid? FieldId { get; set; }
    public Field? Field { get; set; }
    public DateTimeOffset UpdatedAtUtc { get; set; }
    public int? UpdatedByUserId { get; set; }

    // Navigation properties
    public ICollection<Sheep> Sheep { get; set; } = [];
    public Farm Farm { get; set; } = new();
}