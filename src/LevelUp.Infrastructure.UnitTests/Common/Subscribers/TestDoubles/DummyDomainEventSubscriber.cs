using LevelUp.Domain.Common;
using LevelUp.Infrastructure.Common.Subscribers;

namespace LevelUp.Infrastructure.UnitTests.Common.Subscribers.TestDoubles;

public class DummyDomainEventSubscriber : IEventSubscriber
{
    public Task HandleAsync(IDomainEvent domainEvent)
    {
        return Task.CompletedTask;
    }

    public override string ToString() => nameof(DummyDomainEventSubscriber);

    public override bool Equals(object? obj)
    {
        return this.ToString() == (obj as DummyDomainEventSubscriber)!.ToString();
    }
}