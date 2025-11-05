namespace FlockWise.Application.Models.Sheep;

public class AddSheepDto
{
    public int FarmId { get; set; }
    public Guid FlockId { get; set; }
    public Breed Breed { get; set; }
    public string? Pedigree { get; set; }
    public Sex Sex { get; set; }
    public string? FeetHealth { get; set; }
    public int? NumberOfTeeth { get; set; }
    public SheepStatus Status { get; set; } = SheepStatus.Alive;
    public LifeStage LifeStage { get; set; }
    public SheepType? SheepType { get; set; }
}