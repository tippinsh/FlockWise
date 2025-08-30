namespace FlockWise.Core.Events.Flocks;

public class FlockCreated(int flockId, DateTimeOffset establishedDate) : DomainEvent
{
    public int FlockId { get; set; } = flockId;
    public DateTimeOffset EstablishedDate { get; set; } = establishedDate;
}