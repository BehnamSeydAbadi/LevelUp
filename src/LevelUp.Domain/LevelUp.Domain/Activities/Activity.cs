using LevelUp.Domain.Common;

namespace LevelUp.Domain.Activities;

public class Activity : AggregateRoot<Guid>
{
    public static Activity Create(string name, DateTimeOffset date, TimeSpan duration, string category)
        => new(Guid.NewGuid(), name, date, duration, category);

    [PersistenceOnlyPurpose]
    public Activity()
    {
    }

    private Activity(Guid id, string name, DateTimeOffset date, TimeSpan duration, string category)
    {
        Id = id;
        Name = name;
        Date = date;
        Duration = duration;
        Category = category;
    }

    public string Name { get; set; }
    public DateTimeOffset Date { get; set; }
    public TimeSpan Duration { get; set; }
    public string Category { get; set; }
}