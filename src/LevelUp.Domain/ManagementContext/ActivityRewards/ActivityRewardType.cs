namespace LevelUp.Domain.ManagementContext.ActivityRewards;

public enum ActivityRewardType : byte
{
    ActionActivityToActionReward = 1,
    ActionActivityToDurativeReward,
    DurativeActivityToActionReward,
    DurativeActivityToDurativeReward,
}