using LevelUp.Domain.Common.Events;

namespace LevelUp.Domain.Common;

public abstract class AggregateRoot<TId> : Entity<TId>
{
    private readonly Queue<AbstractDomainEvent> _domainEvents = [];

    protected void QueueEvent<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : AbstractDomainEvent
    {
        _domainEvents.Enqueue(domainEvent);
    }

    public AbstractDomainEvent[] GetQueuedEvents() => _domainEvents.ToArray();
}