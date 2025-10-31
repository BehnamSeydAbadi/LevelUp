using LevelUp.Domain.TrackingContext.Users;

namespace LevelUp.Domain.UnitTests.TrackingContext.Users;

public class UserRewardTests
{
    [Fact(DisplayName = "When a user achieves a durative reward, Then it is done successfully")]
    public void When_A_User_Achieves_A_Durative_Reward_Then_It_Is_Done_Successfully()
    {
        var rewardId = Guid.NewGuid();
        var duration = new TimeSpan(hours: 0, minutes: 20, seconds: 0);

        var userReward = UserReward.CreateDurative(rewardId, duration);

        userReward.Id.Should().NotBe(Guid.Empty);
        userReward.RewardId.Should().Be(rewardId);
        userReward.Duration.Should().Be(duration);
        userReward.AchievedAt.Should().BeCloseTo(DateTimeOffset.Now, TimeSpan.FromSeconds(5));
    }

    [Fact(DisplayName = "When a user achieves an action reward, Then it is done successfully")]
    public void When_A_User_Achieves_An_Action_Reward_Then_It_Is_Done_Successfully()
    {
        var rewardId = Guid.NewGuid();

        var userReward = UserReward.CreateAction(rewardId);

        userReward.Id.Should().NotBe(Guid.Empty);
        userReward.RewardId.Should().Be(rewardId);
        userReward.AchievedAt.Should().BeCloseTo(DateTimeOffset.Now, TimeSpan.FromSeconds(5));
    }
}