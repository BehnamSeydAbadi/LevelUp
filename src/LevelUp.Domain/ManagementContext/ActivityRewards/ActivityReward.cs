using LevelUp.Domain.Common;
using LevelUp.Domain.Common.Attributes;

namespace LevelUp.Domain.ManagementContext.ActivityRewards;

public class ActivityReward : AggregateRoot<Guid>
{
    [PersistenceOnlyPurpose]
    protected ActivityReward()
    {
    }

    public static ActivityReward Link(Guid activityId, Guid rewardId)
    {
        return new ActivityReward
        {
            Id = Guid.NewGuid(),
            ActivityId = activityId,
            RewardId = rewardId
        };
    }

    public Guid ActivityId { get; set; }
    public Guid RewardId { get; set; }
}