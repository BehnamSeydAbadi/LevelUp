namespace LevelUp.Application.DurativeRewards.UseCases.UpdateDurativeReward;

public class UpdateDurativeRewardRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public TimeSpan Duration { get; set; }
    public string Category { get; set; }
    public DateTimeOffset ExpireDate { get; set; }
}