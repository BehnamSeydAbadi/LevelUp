using LevelUp.Domain.Common;
using LevelUp.Infrastructure.Common.Subscribers;

namespace LevelUp.Infrastructure.UnitTests.Common.Subscribers.TestDoubles;

public class DummyDomainEventSubscriber : IEventSubscriber
{
    public Guid Id { get; private set; } = Guid.Empty;

    public DummyDomainEventSubscriber(bool isUnique = false)
    {
        if (isUnique) Id = Guid.NewGuid();
    }

    public Task HandleAsync(IDomainEvent domainEvent)
    {
        return Task.CompletedTask;
    }

    public override string ToString() => $"{nameof(DummyDomainEventSubscriber)}_{Id}";

    public override bool Equals(object? obj)
    {
        return this.ToString() == (obj as DummyDomainEventSubscriber)!.ToString();
    }
}