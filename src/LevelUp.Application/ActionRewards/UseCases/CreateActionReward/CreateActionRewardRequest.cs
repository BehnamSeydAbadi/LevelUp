namespace LevelUp.Application.ActionRewards.UseCases.CreateActionReward;

public class CreateActionRewardRequest
{
    public string Name { get; set; }
    public DateTimeOffset Date { get; set; }
    public string Category { get; set; }
}