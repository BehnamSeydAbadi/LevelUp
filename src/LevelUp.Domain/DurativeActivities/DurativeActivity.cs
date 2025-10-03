using LevelUp.Domain.Common;

namespace LevelUp.Domain.DurativeActivities;

public class DurativeActivity : AggregateRoot<Guid>
{
    public static DurativeActivity Create(string name, DateTimeOffset date, TimeSpan duration, string category)
        => new(Guid.NewGuid(), name, date, duration, category);

    [PersistenceOnlyPurpose]
    public DurativeActivity()
    {
    }

    private DurativeActivity(Guid id, string name, DateTimeOffset date, TimeSpan duration, string category)
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