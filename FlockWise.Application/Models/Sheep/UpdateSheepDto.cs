namespace FlockWise.Application.Models.Sheep;

public class UpdateSheepDto
{
    public Guid Id { get; set; }
    public Guid FlockId { get; set; }
    public string? Pedigree { get; set; }
    public string? FeetHealth { get; set; }
    public int? NumberOfTeeth { get; set; }
    public SheepStatus Status { get; set; }
    public LifeStage LifeStage { get; set; }
    public SheepType? SheepType { get; set; }
    public DateTimeOffset? DateOfDeath { get; set; }
}