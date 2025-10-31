using LevelUp.Domain.Common;
using LevelUp.Domain.Common.Attributes;

namespace LevelUp.Domain.TrackingContext.Users;

public class UserReward : Entity<Guid>
{
    public Guid RewardId { get; set; }
    public TimeSpan? Duration { get; set; }
    public DateTimeOffset Date { get; set; }


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
            Date = DateTimeOffset.Now,
        };
    }
}