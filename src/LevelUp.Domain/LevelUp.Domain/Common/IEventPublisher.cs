namespace LevelUp.Domain.Common;

public interface IEventPublisher
{
    Task PublishAsync(IDomainEvent[] domainEvents);
}