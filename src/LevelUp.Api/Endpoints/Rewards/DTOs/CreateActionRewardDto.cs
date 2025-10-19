namespace LevelUp.Api.Endpoints.Rewards.DTOs;

public class CreateActionRewardDto
{
    public string Name { get; init; }
    public DateTimeOffset Date { get; init; }
    public string Category { get; init; }
}