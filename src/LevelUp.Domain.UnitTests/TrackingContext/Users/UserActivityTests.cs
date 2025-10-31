using LevelUp.Domain.TrackingContext.Users;

namespace LevelUp.Domain.UnitTests.TrackingContext.Users;

public class UserActivityTests
{
    [Fact(DisplayName = "When a user performs a durative activity, Then it is done successfully")]
    public void When_A_User_Activity_Gets_Performed_Then_It_Is_Done_Successfully()
    {
        var activityId = Guid.NewGuid();
        var date = DateTimeOffset.Now;
        var duration = new TimeSpan(hours: 0, minutes: 20, seconds: 0);

        var userActivity = UserActivity.CreateDurative(activityId, date, duration);

        userActivity.Id.Should().NotBe(Guid.Empty);
        userActivity.ActivityId.Should().Be(activityId);
        userActivity.PerformedAt.Should().Be(date);
        userActivity.Duration.Should().Be(duration);
    }

    [Fact(DisplayName = "When a user performs an action activity, Then it is done successfully")]
    public void When_A_User_Performs_An_Action_Activity_Then_It_Is_Done_Successfully()
    {
        var activityId = Guid.NewGuid();
        var date = DateTimeOffset.Now;

        var userActivity = UserActivity.CreateAction(activityId, date);

        userActivity.Id.Should().NotBe(Guid.Empty);
        userActivity.ActivityId.Should().Be(activityId);
        userActivity.PerformedAt.Should().Be(date);
        userActivity.Duration.Should().BeNull();
    }
}