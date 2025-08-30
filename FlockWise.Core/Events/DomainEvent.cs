namespace FlockWise.Core.Events;

public class DomainEvent : IDomainEvent
{
    public DateTimeOffset OccurredOn { get; protected set; } = DateTimeOffset.UtcNow;
}