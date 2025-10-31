namespace LevelUp.Domain.Common.Events;

public class AbstractDomainEvent
{
    public DateTimeOffset CreationDateTime { get; init; }
}