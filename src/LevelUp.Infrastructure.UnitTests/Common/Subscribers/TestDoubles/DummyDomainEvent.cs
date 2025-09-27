using LevelUp.Domain.Common;

namespace LevelUp.Infrastructure.UnitTests.Common.Subscribers.TestDoubles;

public class DummyDomainEvent : IDomainEvent
{
    public Guid AggregateId { get; set; }
    public DateTimeOffset PublishDateTime { get; set; }
}