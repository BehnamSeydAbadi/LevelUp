using LevelUp.Domain.ManagementContext.ActionActivities;

namespace LevelUp.Domain.UnitTests.ManagementContext.ActionActivities;

public class ActionActivityTests
{
    [Fact(DisplayName = "When an action activity is created, Then it is done successfully")]
    public void When_An_Action_Activity_Is_Created_Then_It_Is_Done_Successfully()
    {
        const string name = "activity-name";
        var date = DateTimeOffset.Now;
        const string category = "activity-category";
        var rewardId = Guid.NewGuid();

        var activity = ActionActivity.Create(name, date, category, rewardId);

        activity.Id.Should().NotBe(Guid.Empty);
        activity.Name.Should().Be(name);
        activity.Date.Should().Be(date);
        activity.Category.Should().Be(category);
        activity.RewardId.Should().Be(rewardId);
    }

    [Fact(DisplayName = "When an action activity is updated, Then it is done successfully")]
    public void When_An_Action_Activity_Is_Updated_Then_It_Is_Done_Successfully()
    {
        const string name = "activity-name";
        var date = DateTimeOffset.Now;
        const string category = "activity-category";

        var activity = Builder<ActionActivity>.CreateNew().Build();


        activity.Update(name, date, category);


        activity.Name.Should().Be(name);
        activity.Date.Should().Be(date);
        activity.Category.Should().Be(category);
    }
}