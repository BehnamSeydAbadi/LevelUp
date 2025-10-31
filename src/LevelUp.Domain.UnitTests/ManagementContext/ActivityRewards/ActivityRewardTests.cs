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

        var activityReward = ActivityReward.LinkActionActivityToActionReward(activityId, rewardId);

        activityReward.Id.Should().NotBe(Guid.Empty);
        activityReward.ActivityId.Should().Be(activityId);
        activityReward.ActivityDuration.Should().BeNull();
        activityReward.RewardId.Should().Be(rewardId);
        activityReward.RewardDuration.Should().BeNull();
        activityReward.LinkType.Should().Be(ActivityRewardType.ActionActivityToActionReward);
    }

    [Fact(DisplayName =
        "There is an action activity and a durative reward, When these two are linked, Then it is done successfully")]
    public void
        There_Is_An_Action_Activity_And_A_Durative_Reward_When_These_Two_Are_Linked_Then_It_Is_Done_Successfully()
    {
        var activityId = Guid.NewGuid();
        var rewardId = Guid.NewGuid();
        var rewardDuration = new TimeSpan(hours: 0, minutes: 30, seconds: 0);

        var activityReward = ActivityReward.LinkActionActivityToDurativeReward(activityId, rewardId, rewardDuration);

        activityReward.Id.Should().NotBe(Guid.Empty);
        activityReward.ActivityId.Should().Be(activityId);
        activityReward.ActivityDuration.Should().BeNull();
        activityReward.RewardId.Should().Be(rewardId);
        activityReward.RewardDuration.Should().Be(rewardDuration);
        activityReward.LinkType.Should().Be(ActivityRewardType.ActionActivityToDurativeReward);
    }

    [Fact(DisplayName =
        "There is a durative activity and an action reward, When these two are linked, Then it is done successfully")]
    public void
        There_Is_A_Durative_Activity_And_An_Action_Reward_When_These_Two_Are_Linked_Then_It_Is_Done_Successfully()
    {
        var activityId = Guid.NewGuid();
        var activityDuration = new TimeSpan(hours: 0, minutes: 30, seconds: 0);
        var rewardId = Guid.NewGuid();

        var activityReward = ActivityReward.LinkDurativeActivityToActionReward(activityId, activityDuration, rewardId);

        activityReward.Id.Should().NotBe(Guid.Empty);
        activityReward.ActivityId.Should().Be(activityId);
        activityReward.ActivityDuration.Should().Be(activityDuration);
        activityReward.RewardId.Should().Be(rewardId);
        activityReward.RewardDuration.Should().BeNull();
        activityReward.LinkType.Should().Be(ActivityRewardType.DurativeActivityToActionReward);
    }

    [Fact(DisplayName =
        "There is a durative activity and a durative reward, When these two are linked, Then it is done successfully")]
    public void
        There_Is_A_Durative_Activity_And_A_Durative_Reward_When_These_Two_Are_Linked_Then_It_Is_Done_Successfully()
    {
        var activityId = Guid.NewGuid();
        var rewardId = Guid.NewGuid();

        var activityReward = ActivityReward.LinkDurativeActivityToDurativeReward(activityId, rewardId);

        activityReward.Id.Should().NotBe(Guid.Empty);
        activityReward.ActivityId.Should().Be(activityId);
        activityReward.ActivityDuration.Should().BeNull();
        activityReward.RewardId.Should().Be(rewardId);
        activityReward.RewardDuration.Should().BeNull();
        activityReward.LinkType.Should().Be(ActivityRewardType.DurativeActivityToDurativeReward);
    }
}