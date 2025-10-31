using LevelUp.Domain.ManagementContext.ActionRewards;

namespace LevelUp.Domain.UnitTests.ManagementContext.ActionRewards;

public class ActionRewardTests
{
    [Fact(DisplayName = "When an action reward is created, Then it is done successfully")]
    public void When_An_Action_Reward_Is_Created_Then_It_Is_Done_Successfully()
    {
        const string name = "reward-name";
        var date = DateTimeOffset.Now;
        const string category = "reward-category";

        
        var reward = ActionReward.Create(name, date, category);

        
        reward.Id.Should().NotBe(Guid.Empty);
        reward.Name.Should().Be(name);
        reward.Date.Should().Be(date);
        reward.Category.Should().Be(category);
    }
    
    [Fact(DisplayName = "When an action reward is updated, Then it is done successfully")]
    public void When_An_Action_Reward_Is_Updated_Then_It_Is_Done_Successfully()
    {
        const string name = "reward-name";
        var date = DateTimeOffset.Now;
        const string category = "reward-category";

        var reward = Builder<ActionReward>.CreateNew().Build();


        reward.Update(name, date, category);


        reward.Name.Should().Be(name);
        reward.Date.Should().Be(date);
        reward.Category.Should().Be(category);
    }
}