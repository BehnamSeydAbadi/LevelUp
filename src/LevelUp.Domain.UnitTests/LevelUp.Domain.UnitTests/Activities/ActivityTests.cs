using LevelUp.Domain.Activities;
using LevelUp.Domain.Activities.Events;

namespace LevelUp.Domain.UnitTests.Activities;

public class ActivityTests
{
    [Fact(DisplayName = "When an activity is created, Then it is done successfully")]
    public void When_An_Activity_Is_Created_Then_It_Is_Done_Successfully()
    {
        const string name = "activity-name";
        var date = DateTimeOffset.Now;
        var duration = new TimeSpan(hours: 1, minutes: 0, seconds: 0);
        const string category = "activity-category";


        var activity = Activity.Create(name, date, duration, category);


        activity.Id.Should().NotBe(Guid.Empty);
        activity.Name.Should().Be(name);
        activity.Date.Should().Be(date);
        activity.Duration.Should().Be(duration);
        activity.Category.Should().Be(category);

        var domainEvents = activity.GetDomainEvents().ToArray();
        domainEvents.Should().HaveCount(1);
        var domainEvent = domainEvents.First() as ActivityCreated;
        domainEvent.Should().NotBeNull();
        domainEvent.AggregateId.Should().Be(activity.Id);
        domainEvent.Name.Should().Be(name);
        domainEvent.Date.Should().Be(date);
        domainEvent.Duration.Should().Be(duration);
        domainEvent.Category.Should().Be(category);
    }
}