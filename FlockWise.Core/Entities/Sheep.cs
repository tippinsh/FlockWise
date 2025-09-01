namespace FlockWise.Core.Entities;

public class Sheep
{
    public Guid Id { get; init; } = SequentialGuidGenerator.NewSequentialGuid();

    public Guid FlockId { get; set; }

    [Required, StringLength(100)]
    public required string Breed { get; init; }

    [StringLength(100)]
    public string? Pedigree { get; set; }
    
    public DateTimeOffset? DateOfBirth { get; init; }

    public DateTimeOffset? DateOfDeath { get; set; }
    
    public Sheep? Father { get; set; }
    
    public Sheep? Mother { get; set; }

    public Sex Sex { get; set; }

    public Weight? WeightBornKgs { get; set; }

    public Weight? CurrentWeight { get; set; }

    [StringLength(100)]
    public string? FeetHealth { get; set; }

    public int? NumberOfTeeth { get; set; }

    [Required]
    public SheepStatus Status { get; set; } = SheepStatus.Alive;

    public bool? BottleFedLamb { get; set; }

    [Required]
    public LifeStage LifeStage { get; set; }

    public SheepType? SheepType { get; set; }
    
    // Navigation properties
    public Flock Flock { get; set; }
}