namespace FlockWise.Core.Aggregates;

public class Sheep
{
    public Guid Id { get; init; }
    
    [Required, StringLength(100)]
    public required string Breed { get; init; }

    [Required, StringLength(100)]
    public required string Pedigree { get; set; }

    [Required]
    public DateTimeOffset DateOfBirth { get; init; }

    public DateTimeOffset? DateOfDeath { get; set; }
    
    public Sheep? Father { get; set; }
    
    public Sheep? Mother { get; set; }

    public Sex Sex { get; set; }

    public Weight? WeightBornKgs { get; set; }

    public Weight? CurrentWeight { get; set; }

    [StringLength(100)]
    public string? FeetHealth { get; set; }

    public int? NumberOfTeeth { get; set; }

    public SheepStatus Status { get; set; }

    public bool? BottleFedLamb { get; set; }

    public LifeStage LifeStage { get; set; }

    public SheepType SheepType { get; set; }
}