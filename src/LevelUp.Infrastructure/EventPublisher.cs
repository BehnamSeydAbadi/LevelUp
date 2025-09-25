using LevelUp.Domain.Common;
using LevelUp.Infrastructure.Common.Subscribers;

namespace LevelUp.Infrastructure;

public class EventPublisher(IEventSubscribersRegistry eventSubscribersRegistry) : IEventPublisher
{
    public async Task PublishAsync(IDomainEvent[] domainEvents)
    {
        foreach (var domainEvent in domainEvents)
        {
            var subscribers = eventSubscribersRegistry.Get(domainEvent.GetType());

            foreach (var subscriber in subscribers)
            {
                await subscriber.HandleAsync(domainEvent);
            }
        }
    }
}