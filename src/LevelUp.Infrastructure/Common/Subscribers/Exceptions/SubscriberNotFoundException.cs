using LevelUp.Infrastructure.Common.Exceptions;

namespace LevelUp.Infrastructure.Common.Subscribers.Exceptions;

public class SubscriberNotFoundException(Type eventType)
    : AbstractInfrastructureException(message: $"Event {eventType.FullName} not found");