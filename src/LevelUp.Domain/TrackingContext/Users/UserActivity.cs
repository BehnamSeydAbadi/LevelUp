using LevelUp.Domain.Common;
using LevelUp.Domain.Common.Attributes;

namespace LevelUp.Domain.TrackingContext.Users;

public class UserActivity : Entity<Guid>
{
    public Guid ActivityId { get; set; }
    public DateTimeOffset Date { get; set; }
    public TimeSpan? Duration { get; set; }

    public static UserActivity CreateDurative(Guid activityId, DateTimeOffset date, TimeSpan duration)
    {
        return new UserActivity
        {
            Id = Guid.NewGuid(),
            ActivityId = activityId,
            Date = date,
            Duration = duration
        };
    }

    public static UserActivity CreateAction(Guid activityId, DateTimeOffset date)
    {
        return new UserActivity
        {
            Id = Guid.NewGuid(),
            ActivityId = activityId,
            Date = date,
        };
    }

    [PersistenceOnlyPurpose]
    protected UserActivity()
    {
    }
}