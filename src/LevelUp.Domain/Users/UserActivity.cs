using LevelUp.Domain.Common;

namespace LevelUp.Domain.Users;

public class UserActivity : Entity<Guid>
{
    public Guid ActivityId { get; set; }
    public DateTimeOffset Date { get; set; }
    public TimeSpan? Duration { get; set; }

    public static UserActivity PerformDurative(Guid activityId, DateTimeOffset date, TimeSpan duration)
    {
        return new UserActivity
        {
            Id = Guid.NewGuid(),
            ActivityId = activityId,
            Date = date,
            Duration = duration
        };
    }

    public static UserActivity PerformAction(Guid activityId, DateTimeOffset date)
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