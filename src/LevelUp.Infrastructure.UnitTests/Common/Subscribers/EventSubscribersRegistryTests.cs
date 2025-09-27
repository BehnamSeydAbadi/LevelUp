using LevelUp.Infrastructure.Common.Subscribers;
using LevelUp.Infrastructure.UnitTests.Common.Subscribers.TestDoubles;

namespace LevelUp.Infrastructure.UnitTests.Common.Subscribers;

public class EventSubscribersRegistryTests
{
    [Fact(DisplayName = "When the event subscribers registered, Then it is done successfully")]
    public void When_The_Event_Subscribers_Registered_Then_It_Is_Done_Successfully()
    {
        var eventSubscribersRegistry = new EventSubscribersRegistry();

        var dummyDomainEventSubscriber = new DummyDomainEventSubscriber();


        eventSubscribersRegistry.Register(typeof(DummyDomainEvent), dummyDomainEventSubscriber);


        var eventSubscribers = eventSubscribersRegistry.Get(typeof(DummyDomainEvent));

        eventSubscribers.Should().HaveCount(1);
        eventSubscribers[0].Equals(dummyDomainEventSubscriber).Should().BeTrue();
    }
}