namespace FlockWise.Core.Entities;

public class Sheep
{
    public Guid Id { get; init; } = SequentialGuidGenerator.NewSequentialGuid();

    [Required]
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public Guid FlockId { get; set; }
    
    [Required, StringLength(100)]
    public required string Breed { get; init; }
    
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
    
    // Navigation properties
    public Flock Flock { get; set; }
    public BirthRecord? BirthRecord { get; set; }
    
    public ICollection<WeightHistory> Weights { get; set; } = [];

}