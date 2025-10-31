using LevelUp.Domain.ManagementContext.ActivityRewards;

namespace LevelUp.Domain.UnitTests.ManagementContext.ActivityRewards;

public class ActivityRewardTests
{
    [Fact(DisplayName =
        "There is an action activity and an action reward, When these two are linked, Then  it is done successfully")]
    public void
        There_Is_An_Action_Activity_And_An_Action_Reward_When_These_Two_Are_Linked_Then_It_Is_Done_Successfully()
    {
        var activityId = Guid.NewGuid();
        var rewardId = Guid.NewGuid();

        var activityReward = ActivityReward.LinkActionActivityToActionReward(activityId, rewardId, rewardAmplifier: 1);

        activityReward.Id.Should().NotBe(Guid.Empty);
        activityReward.ActivityId.Should().Be(activityId);
        activityReward.RewardId.Should().Be(rewardId);
    }

    [Fact(DisplayName =
        "There is an action activity and an action reward, When the amplified reward is linked to the activity, Then  it is done successfully")]
    public void
        There_Is_An_Action_Activity_And_An_Action_Reward_When_The_Amplified_Reward_Is_Linked_To_The_Activity_Then_It_Is_Done_Successfully()
    {
        var activityId = Guid.NewGuid();
        var rewardId = Guid.NewGuid();
        const int rewardAmplifier = 2;

        var activityReward = ActivityReward.LinkActionActivityToActionReward(activityId, rewardId, rewardAmplifier);

        activityReward.Id.Should().NotBe(Guid.Empty);
        activityReward.ActivityId.Should().Be(activityId);
        activityReward.RewardId.Should().Be(rewardId);
        activityReward.RewardAmplifier.Should().Be(rewardAmplifier);
    }
}