namespace FlockWise.Application.Models.Sheep;

public class SheepDto
{
    public Guid Id { get; set; }
    public Guid FlockId { get; set; }
    public required Breed Breed { get; set; }
    public string? Pedigree { get; set; }
    public DateTimeOffset? DateOfBirth { get; set; }
    public DateTimeOffset? DateOfDeath { get; set; }
    public Sex Sex { get; set; }
    public string? FeetHealth { get; set; }
    public int? NumberOfTeeth { get; set; }
    public SheepStatus Status { get; set; }
    public LifeStage LifeStage { get; set; }
    public SheepType? SheepType { get; set; }
    
    // Navigation properties
    public BirthRecordDto? BirthRecord { get; set; }

}