namespace FlockWise.Core.Entities;

public class BirthRecord
{
    public Guid Id { get; set; } = SequentialGuidGenerator.NewSequentialGuid();
    public Guid SheepId { get; set; }
    public DateTimeOffset DateOfBirthUtc { get; set; }
    public double WeightBornKgs { get; set; }
    public bool BottleFedLamb { get; set; }
    public Guid FatherId { get; set; }
    public Guid MotherId { get; set; }
    
    [StringLength(255)]
    public string? BirthComplications { get; set; }

    public DateTimeOffset CreatedAtUtc { get; set; }

    public DateTimeOffset UpdatedAtUtc { get; set; }

    public int UpdatedByUserId { get; set; }
    
    // Navigation properties
    [Required]
    public required Sheep Sheep { get; set; }
    public Sheep? Father { get; set; }
    public Sheep? Mother { get; set; }
}