namespace FlockWise.Core.Events;

public interface IDomainEvent
{
    DateTimeOffset OccurredOn { get; }
}