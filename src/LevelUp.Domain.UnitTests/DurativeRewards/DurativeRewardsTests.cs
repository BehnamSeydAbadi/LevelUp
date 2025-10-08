using LevelUp.Domain.DurativeRewards;

namespace LevelUp.Domain.UnitTests.DurativeRewards;

public class DurativeRewardsTests
{
    [Fact(DisplayName = "When a durative reward is created, Then it is done successfully")]
    public void When_A_Durative_Reward_Is_Created_Then_It_Is_Done_Successfully()
    {
        const string name = "activity-name";
        var duration = new TimeSpan(hours: 1, minutes: 0, seconds: 0);
        const string category = "activity-category";
        var expireDate = DateTimeOffset.Now;


        var reward = DurativeReward.Create(name, duration, category, expireDate);


        reward.Id.Should().NotBe(Guid.Empty);
        reward.Name.Should().Be(name);
        reward.Duration.Should().Be(duration);
        reward.Category.Should().Be(category);
        reward.ExpireDate.Should().Be(expireDate);
    }

    [Fact(DisplayName = "When a durative activity is updated, Then it is done successfully")]
    public void When_A_Durative_Reward_Is_Updated_Then_It_Is_Done_Successfully()
    {
        const string name = "activity-name";
        var duration = new TimeSpan(hours: 1, minutes: 0, seconds: 0);
        const string category = "activity-category";
        var expireDate = DateTimeOffset.Now;

        var reward = Builder<DurativeReward>.CreateNew().Build();


        reward.Update(name, duration, category, expireDate);


        reward.Name.Should().Be(name);
        reward.Duration.Should().Be(duration);
        reward.Category.Should().Be(category);
        reward.ExpireDate.Should().Be(expireDate);
    }
}