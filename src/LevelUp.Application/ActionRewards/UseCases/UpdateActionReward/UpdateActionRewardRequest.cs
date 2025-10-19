namespace LevelUp.Application.ActionRewards.UseCases.UpdateActionReward;

public class UpdateActionRewardRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTimeOffset Date { get; set; }
    public string Category { get; set; }
}