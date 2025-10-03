namespace LevelUp.Domain.Common;

public abstract class AggregateRoot<TId>
{
    public TId Id { get; set; }
}