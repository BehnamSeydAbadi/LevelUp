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

    [Fact(DisplayName =
        "There are more than one event subscriber, When they get registered, Then it is done successfully")]
    public void There_Are_More_Than_One_Event_Subscriber_When_They_Get_Registered_Then_It_Is_Done_Successfully()
    {
        var eventSubscribersRegistry = new EventSubscribersRegistry();

        DummyDomainEventSubscriber[] domainEventSubscribers =
        [
            new(isUnique: true),
            new(isUnique: true),
            new(isUnique: true)
        ];


        foreach (var domainEventSubscriber in domainEventSubscribers)
        {
            eventSubscribersRegistry.Register(typeof(DummyDomainEvent), domainEventSubscriber);
        }


        var eventSubscribers = eventSubscribersRegistry.Get(typeof(DummyDomainEvent));

        eventSubscribers.Should().HaveCount(domainEventSubscribers.Length);
        
        eventSubscribers
            .GroupBy(es => (es as DummyDomainEventSubscriber)!.Id)
            .Any(g => g.Count() > 1).Should().BeFalse();
    }
}