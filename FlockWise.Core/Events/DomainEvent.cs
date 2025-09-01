namespace FlockWise.Core.Events;

public class DomainEvent : IDomainEvent
{
    public DateTimeOffset OccurredOn { get; protected set; } = DateTimeOffset.UtcNow;
    
    // Idempotency key
    public Guid EventId { get; set; } =  Guid.NewGuid();
}