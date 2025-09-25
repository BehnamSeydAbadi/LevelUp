using LevelUp.Domain.Common;

namespace LevelUp.Domain.Activities.Events;

public class ActivityCreated : AbstractDomainEvent
{
    public string Name { get; set; }
    public DateTimeOffset Date { get; set; }
    public TimeSpan Duration { get; set; }
    public string Category { get; set; }
}