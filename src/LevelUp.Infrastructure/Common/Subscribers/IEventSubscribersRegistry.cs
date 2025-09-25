namespace LevelUp.Infrastructure.Common.Subscribers;

public interface IEventSubscribersRegistry
{
    void Register(Type eventType, IEventSubscriber eventSubscriber);
    IEventSubscriber[] Get(Type eventType);
}