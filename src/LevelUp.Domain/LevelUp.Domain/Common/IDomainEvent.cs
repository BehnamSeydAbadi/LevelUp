namespace LevelUp.Domain.Common;

public interface IDomainEvent
{
    Guid AggregateId { get; set; }
    DateTimeOffset PublishDateTime { get; set; }
}

public abstract class AbstractDomainEvent : IDomainEvent
{
    public required Guid AggregateId { get; set; }
    public DateTimeOffset PublishDateTime { get; set; } = DateTimeOffset.Now;
}