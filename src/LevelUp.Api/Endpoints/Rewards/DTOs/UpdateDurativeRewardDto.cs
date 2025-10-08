namespace LevelUp.Api.Endpoints.Rewards.DTOs;

public class UpdateDurativeRewardDto
{
    public string Name { get; init; }
    public DateTimeOffset ExpireDate { get; init; }
    public string Duration { get; init; }
    public string Category { get; init; }
}