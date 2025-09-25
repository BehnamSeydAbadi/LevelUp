using LevelUp.Infrastructure.Common.Subscribers.Exceptions;

namespace LevelUp.Infrastructure.Common.Subscribers;

public class EventSubscribersRegistry : IEventSubscribersRegistry
{
    private readonly Dictionary<string, List<IEventSubscriber>> _eventSubscribersIndexedByEventType = new();

    public void Register(Type eventType, IEventSubscriber eventSubscriber)
    {
        var key = KeyGenerator(eventType);

        if (_eventSubscribersIndexedByEventType.TryGetValue(key, out var eventSubscribers))
        {
            eventSubscribers.Add(eventSubscriber);
        }
        else
        {
            _eventSubscribersIndexedByEventType.Add(key, [eventSubscriber]);
        }
    }

    public IEventSubscriber[] Get(Type eventType)
    {
        var key = KeyGenerator(eventType);

        return _eventSubscribersIndexedByEventType.TryGetValue(key, out var eventSubscribers) is false
            ? throw new SubscriberNotFoundException(eventType)
            : eventSubscribers.ToArray();
    }


    private static string KeyGenerator(Type eventType)
    {
        return $"{eventType.FullName}_{eventType.Assembly.GetName().Name}";
    }
}