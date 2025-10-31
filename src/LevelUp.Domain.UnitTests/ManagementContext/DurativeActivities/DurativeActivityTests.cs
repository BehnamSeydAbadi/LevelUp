using LevelUp.Domain.ManagementContext.DurativeActivities;

namespace LevelUp.Domain.UnitTests.ManagementContext.DurativeActivities;

public class DurativeActivityTests
{
    [Fact(DisplayName = "When a durative activity is created, Then it is done successfully")]
    public void When_A_Durative_Activity_Is_Created_Then_It_Is_Done_Successfully()
    {
        const string name = "activity-name";
        var date = DateTimeOffset.Now;
        var duration = new TimeSpan(hours: 1, minutes: 0, seconds: 0);
        const string category = "activity-category";


        var activity = DurativeActivity.Create(name, date, duration, category);


        activity.Id.Should().NotBe(Guid.Empty);
        activity.Name.Should().Be(name);
        activity.Date.Should().Be(date);
        activity.Duration.Should().Be(duration);
        activity.Category.Should().Be(category);
    }

    [Fact(DisplayName = "When a durative activity is updated, Then it is done successfully")]
    public void When_A_Durative_Activity_Updated_Then_It_Is_Done_Successfully()
    {
        const string name = "activity-name";
        var date = DateTimeOffset.Now;
        var duration = new TimeSpan(hours: 1, minutes: 0, seconds: 0);
        const string category = "activity-category";

        var activity = Builder<DurativeActivity>.CreateNew().Build();

        
        activity.Update(name, date, duration, category);


        activity.Name.Should().Be(name);
        activity.Date.Should().Be(date);
        activity.Duration.Should().Be(duration);
        activity.Category.Should().Be(category);
    }
}