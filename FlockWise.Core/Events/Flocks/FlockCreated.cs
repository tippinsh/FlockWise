namespace FlockWise.Core.Events.Flocks;

public class FlockCreated(Guid id, DateTimeOffset establishedDate) : DomainEvent
{
    public Guid Id { get; set; } = id;
    public DateTimeOffset EstablishedDate { get; set; } = establishedDate;
}