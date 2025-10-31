using LevelUp.Domain.Common;
using LevelUp.Domain.Common.Attributes;

namespace LevelUp.Domain.ManagementContext.ActivityRewards;

public class ActivityReward : AggregateRoot<Guid>
{
    [PersistenceOnlyPurpose]
    protected ActivityReward()
    {
    }

    public static ActivityReward LinkActionActivityToActionReward(Guid activityId, Guid rewardId)
    {
        return new ActivityReward
        {
            Id = Guid.NewGuid(),
            ActivityId = activityId,
            RewardId = rewardId,
            LinkType = ActivityRewardType.ActionActivityToActionReward
        };
    }

    /// <param name="rewardDuration">Achieving reward duration per performed action activity</param>
    public static ActivityReward LinkActionActivityToDurativeReward(
        Guid activityId, Guid rewardId, TimeSpan rewardDuration
    )
    {
        return new ActivityReward
        {
            Id = Guid.NewGuid(),
            ActivityId = activityId,
            RewardId = rewardId,
            RewardDuration = rewardDuration,
            LinkType = ActivityRewardType.ActionActivityToDurativeReward
        };
    }

    /// <param name="activityDuration">The amount of activity needs to be done in order to make the reward achievable</param>
    public static ActivityReward LinkDurativeActivityToActionReward(
        Guid activityId, TimeSpan activityDuration, Guid rewardId
    )
    {
        return new ActivityReward
        {
            Id = Guid.NewGuid(),
            ActivityId = activityId,
            ActivityDuration = activityDuration,
            RewardId = rewardId,
            LinkType = ActivityRewardType.DurativeActivityToActionReward
        };
    }

    public static ActivityReward LinkDurativeActivityToDurativeReward(Guid activityId, Guid rewardId)
    {
        return new ActivityReward
        {
            Id = Guid.NewGuid(),
            ActivityId = activityId,
            RewardId = rewardId,
            LinkType = ActivityRewardType.DurativeActivityToDurativeReward
        };
    }


    public Guid ActivityId { get; set; }
    public TimeSpan? ActivityDuration { get; set; }
    public Guid RewardId { get; set; }
    public TimeSpan? RewardDuration { get; set; }
    public ActivityRewardType LinkType { get; set; }
}