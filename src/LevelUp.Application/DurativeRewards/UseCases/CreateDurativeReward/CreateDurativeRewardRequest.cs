namespace LevelUp.Application.DurativeRewards.UseCases.CreateDurativeReward;

public class CreateDurativeRewardRequest
{
    public string Name { get; set; }
    public TimeSpan Duration { get; set; }
    public string Category { get; set; }
    public DateTimeOffset ExpireDate { get; set; }
}