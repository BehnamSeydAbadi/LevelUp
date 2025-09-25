using LevelUp.Domain.Common;

namespace LevelUp.Infrastructure.Common.Subscribers;

public interface IEventSubscriber
{
    Task HandleAsync(IDomainEvent domainEvent);
}