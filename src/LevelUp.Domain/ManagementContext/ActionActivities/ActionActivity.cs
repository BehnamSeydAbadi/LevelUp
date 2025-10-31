using LevelUp.Domain.Common;

namespace LevelUp.Domain.ManagementContext.ActionActivities;

public class ActionActivity : AggregateRoot<Guid>
{
    public static ActionActivity Create(string name, DateTimeOffset date, string category, Guid rewardId)
    {
        return new ActionActivity
        {
            Id = Guid.NewGuid(),
            Name = name,
            Date = date,
            Category = category,
            RewardId = rewardId
        };
    }

    public string Name { get; set; }
    public DateTimeOffset Date { get; set; }
    public string Category { get; set; }
    public Guid RewardId { get; set; }

    public void Update(string name, DateTimeOffset date, string category)
    {
        Name = name;
        Date = date;
        Category = category;
    }
}