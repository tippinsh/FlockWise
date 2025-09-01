namespace FlockWise.Core.Events.Flocks;

public class SheepAddedToFlock : DomainEvent
{
    public Guid FlockId { get; set; }
    public Guid SheepId { get; set; }
}