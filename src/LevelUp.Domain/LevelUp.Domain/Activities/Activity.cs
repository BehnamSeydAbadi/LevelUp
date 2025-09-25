using LevelUp.Domain.Activities.Events;
using LevelUp.Domain.Common;

namespace LevelUp.Domain.Activities;

public class Activity : AggregateRoot<Guid>
{
    public static Activity Create(string name, DateTimeOffset date, TimeSpan duration, string category)
        => new(Guid.NewGuid(), name, date, duration, category);

    [PersistenceOnlyPurpose]
    protected Activity()
    {
    }

    private Activity(Guid id, string name, DateTimeOffset date, TimeSpan duration, string category)
    {
        Id = id;
        Name = name;
        Date = date;
        Duration = duration;
        Category = category;
        
        Queue(new ActivityCreated
        {
            AggregateId = id,
            Name = name,
            Date = date,
            Duration = duration,
            Category = category
        });
    }

    public string Name { get; private set; }
    public DateTimeOffset Date { get; private set; }
    public TimeSpan Duration { get; private set; }
    public string Category { get; private set; }
}