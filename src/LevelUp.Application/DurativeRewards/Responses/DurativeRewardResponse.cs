using LevelUp.Domain.ManagementContext.DurativeRewards;

namespace LevelUp.Application.DurativeRewards.Responses;

public class DurativeRewardResponse
{
    public static DurativeRewardResponse Map(DurativeReward entity)
    {
        return new DurativeRewardResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Duration = entity.Duration.ToString("c"),
            Category = entity.Category,
            ExpireDate = entity.ExpireDate
        };
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Duration { get; set; }
    public string Category { get; set; }
    public DateTimeOffset ExpireDate { get; set; }
}