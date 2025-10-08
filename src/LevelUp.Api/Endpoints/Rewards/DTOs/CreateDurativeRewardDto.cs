namespace LevelUp.Api.Endpoints.Rewards.DTOs;

public class CreateDurativeRewardDto
{
    public string Name { get; set; }
    public DateTimeOffset ExpireDate { get; set; }
    public string Duration { get; set; }
    public string Category { get; set; }
}