using LevelUp.Domain.Common;
using LevelUp.Domain.Common.Attributes;

namespace LevelUp.Domain.TrackingContext.Users;

public class UserActivity : Entity<Guid>
{
    public Guid ActivityId { get; set; }
    public DateTimeOffset PerformedAt { get; set; }
    public TimeSpan? Duration { get; set; }

    public static UserActivity CreateDurative(Guid activityId, DateTimeOffset performedAt, TimeSpan duration)
    {
        return new UserActivity
        {
            Id = Guid.NewGuid(),
            ActivityId = activityId,
            PerformedAt = performedAt,
            Duration = duration
        };
    }

    public static UserActivity CreateAction(Guid activityId, DateTimeOffset performedAt)
    {
        return new UserActivity
        {
            Id = Guid.NewGuid(),
            ActivityId = activityId,
            PerformedAt = performedAt,
        };
    }

    [PersistenceOnlyPurpose]
    protected UserActivity()
    {
    }
}