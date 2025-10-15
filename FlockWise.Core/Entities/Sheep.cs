namespace FlockWise.Core.Entities;

public class Sheep
{
    public Guid Id { get; init; } = SequentialGuidGenerator.NewSequentialGuid();

    public Guid FarmId { get; set; }

    public string EidTag { get; set; } = string.Empty;
    
    public string UniqueIdentificationNumber { get; set; } = string.Empty;
    
    public string CountryCode { get; set; } = string.Empty;
    
    public Guid FlockId { get; set; }
    
    [Required, StringLength(100)]
    public required Breed Breed { get; init; }
    
    [StringLength(100)]
    public string? Pedigree { get; set; }
    
    public DateTimeOffset? DateOfDeath { get; set; }
    
    public Sex Sex { get; set; }
    
    [StringLength(100)]
    public string? FeetHealth { get; set; }
    
    public int? NumberOfTeeth { get; set; }
    
    [Required]
    public SheepStatus Status { get; set; } = SheepStatus.Alive;
    
    [Required]
    public LifeStage LifeStage { get; set; }
    
    public SheepType? SheepType { get; set; }

    public MotheringAbility? MotheringAbility { get; set; }

    public DateTimeOffset? UpdatedAtUtc { get; set; }

    public int? UpdatedByUserId { get; set; }

    // Navigation properties
    public Flock? Flock { get; set; }
    public BirthRecord? BirthRecord { get; set; }
    public ICollection<WeightHistory> Weights { get; set; } = [];

}