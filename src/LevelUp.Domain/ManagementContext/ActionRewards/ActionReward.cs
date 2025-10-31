using LevelUp.Domain.Common;

namespace LevelUp.Domain.ManagementContext.ActionRewards;

public class ActionReward : AggregateRoot<Guid>
{
    public static ActionReward Create(string name, DateTimeOffset date, string category)
    {
        return new ActionReward
        {
            Id = Guid.NewGuid(),
            Name = name,
            Date = date,
            Category = category
        };
    }

    public string Name { get; set; }
    public DateTimeOffset Date { get; set; }
    public string Category { get; set; }

    public void Update(string name, DateTimeOffset date, string category)
    {
        Name = name;
        Date = date;
        Category = category;
    }
}