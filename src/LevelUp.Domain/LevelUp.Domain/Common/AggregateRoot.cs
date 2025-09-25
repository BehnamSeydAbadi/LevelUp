namespace LevelUp.Domain.Common;

public abstract class AggregateRoot<TId>
{
    private readonly Queue<IDomainEvent> _events = new();

    public TId Id { get; protected set; }

    protected void Queue(IDomainEvent @event) => _events.Enqueue(@event);

    public IEnumerable<IDomainEvent> GetDomainEvents() => _events.ToArray();
}