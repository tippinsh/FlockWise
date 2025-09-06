namespace FlockWise.Core.Events.Sheep;

public class SheepAdded : DomainEvent
{
    public Guid Id { get; set; }
    public Guid? FlockId { get; set; }
    public string? Breed { get; set; }
    public string? Pedigree { get; set; }
    public Sex Sex { get; set; }
    public decimal WeightKg { get; set; }
    public LifeStage LifeStage { get; set; }
    public SheepType? SheepType { get; set; }
}