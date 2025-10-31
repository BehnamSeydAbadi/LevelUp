using LevelUp.Domain.Common.Events;

namespace LevelUp.Domain.TrackingContext.Users.Events;

public class UserPerformedADurativeActivity : AbstractDomainEvent
{
    public UserPerformedADurativeActivity(Guid id, Guid activityId, TimeSpan duration)
    {
        Id = id;
        ActivityId = activityId;
        Duration = duration;
        CreationDateTime = DateTimeOffset.Now;
    }

    public Guid Id { get; init; }
    public Guid ActivityId { get; init; }
    public TimeSpan Duration { get; init; }
}