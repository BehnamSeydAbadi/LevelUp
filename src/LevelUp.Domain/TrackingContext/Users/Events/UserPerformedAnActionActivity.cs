using LevelUp.Domain.Common.Events;

namespace LevelUp.Domain.TrackingContext.Users.Events;

public class UserPerformedAnActionActivity : AbstractDomainEvent
{
    public UserPerformedAnActionActivity(Guid id, Guid activityId)
    {
        Id = id;
        ActivityId = activityId;
        CreationDateTime = DateTimeOffset.Now;
    }

    public Guid Id { get; init; }
    public Guid ActivityId { get; init; }
}