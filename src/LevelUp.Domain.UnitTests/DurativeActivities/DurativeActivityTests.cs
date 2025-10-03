using LevelUp.Domain.DurativeActivities;

namespace LevelUp.Domain.UnitTests.DurativeActivities;

public class DurativeActivityTests
{
    [Fact(DisplayName = "When an activity is created, Then it is done successfully")]
    public void When_An_Activity_Is_Created_Then_It_Is_Done_Successfully()
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
}