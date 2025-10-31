using LevelUp.Domain.Common;
using LevelUp.Domain.Common.Attributes;

namespace LevelUp.Domain.TrackingContext.Users;

public class UserReward : Entity<Guid>
{
    [PersistenceOnlyPurpose]
    protected UserReward()
    {
    }

    public static UserReward CreateDurative(Guid rewardId, TimeSpan duration)
    {
        return new UserReward
        {
            Id = Guid.NewGuid(),
            RewardId = rewardId,
            Duration = duration,
            AchievedAt = DateTimeOffset.Now,
        };
    }

    public static UserReward CreateAction(Guid rewardId)
    {
        return new UserReward
        {
            Id = Guid.NewGuid(),
            RewardId = rewardId,
            AchievedAt = DateTimeOffset.Now,
        };
    }

    public void MarkAsUsed()
    {
        IsUsed = true;
        UsedAt = DateTimeOffset.Now;
    }

    public void MarkAsUsed(TimeSpan duration)
    {
        UsedDuration = duration <= this.Duration!.Value
            ? duration
            : this.Duration.Value;

        UsedAt = DateTimeOffset.Now;

        IsUsed = UsedDuration!.Value == Duration!.Value;
    }


    public Guid RewardId { get; set; }
    public TimeSpan? Duration { get; set; }
    public TimeSpan? UsedDuration { get; set; }
    public DateTimeOffset AchievedAt { get; set; }
    public bool IsUsed { get; set; }
    public DateTimeOffset? UsedAt { get; set; }
}