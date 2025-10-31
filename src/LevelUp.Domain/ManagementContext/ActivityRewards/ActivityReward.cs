using LevelUp.Domain.Common;
using LevelUp.Domain.Common.Attributes;

namespace LevelUp.Domain.ManagementContext.ActivityRewards;

public class ActivityReward : AggregateRoot<Guid>
{
    [PersistenceOnlyPurpose]
    protected ActivityReward()
    {
    }

    public static ActivityReward LinkActionActivityToActionReward(Guid activityId, Guid rewardId, int rewardAmplifier)
    {
        return new ActivityReward
        {
            Id = Guid.NewGuid(),
            ActivityId = activityId,
            RewardId = rewardId,
            RewardAmplifier = rewardAmplifier
        };
    }


    public Guid ActivityId { get; set; }
    public Guid RewardId { get; set; }
    public int? RewardAmplifier { get; set; }
}