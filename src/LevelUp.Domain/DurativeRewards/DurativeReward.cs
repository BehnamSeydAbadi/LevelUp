using LevelUp.Domain.Common;

namespace LevelUp.Domain.DurativeRewards;

public class DurativeReward : AggregateRoot<Guid>
{
    public static DurativeReward Create(string name, TimeSpan duration, string category, DateTimeOffset expireDate)
    {
        return new DurativeReward
        {
            Id = Guid.NewGuid(),
            Name = name,
            Duration = duration,
            Category = category,
            ExpireDate = expireDate
        };
    }

    public string Name { get; set; }
    public TimeSpan Duration { get; set; }
    public string Category { get; set; }
    public DateTimeOffset ExpireDate { get; set; }

    public void Update(string name, TimeSpan duration, string category, DateTimeOffset expireDate)
    {
        Name = name;
        Duration = duration;
        Category = category;
        ExpireDate = expireDate;
    }
}