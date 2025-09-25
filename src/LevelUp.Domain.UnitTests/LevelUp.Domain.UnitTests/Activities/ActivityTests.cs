namespace LevelUp.Domain.UnitTests.Activities;

public class ActivityTests
{
    [Fact(DisplayName = "When an activity is created, Then it is done successfully")]
    public void When_An_Activity_Is_Created_Then_It_Is_Done_Successfully()
    {
        var id = Guid.NewGuid();
        const string name = "activity-name";
        var date = DateTimeOffset.Now;
        var duration = new TimeSpan(hours: 1, minutes: 0, seconds: 0);
        const string category = "activity-category";


        var activity = new Activity(id, name, date, duration, category);


        activity.Id.Should().Be(id);
        activity.Name.Should().Be(name);
        activity.Date.Should().Be(date);
        activity.Duration.Should().Be(duration);
        activity.Category.Should().Be(category);
    }
}

public class Activity
{
    protected Activity()
    {
    }

    public Activity(Guid id, string name, DateTimeOffset date, TimeSpan duration, string category)
    {
        Id = id;
        Name = name;
        Date = date;
        Duration = duration;
        Category = category;
    }

    public Guid Id { get; set; }
    public string Name { get; private set; }
    public DateTimeOffset Date { get; private set; }
    public TimeSpan Duration { get; private set; }
    public string Category { get; private set; }
}