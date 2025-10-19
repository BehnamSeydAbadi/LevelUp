using LevelUp.Domain.ActionRewards;

namespace LevelUp.Application.ActionRewards.UseCases.GetActionReward;

public class ActionRewardResponse
{
    public static ActionRewardResponse Map(ActionReward entity)
    {
        return new ActionRewardResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Date = entity.Date,
            Category = entity.Category
        };
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTimeOffset Date { get; set; }
    public string Category { get; set; }
}