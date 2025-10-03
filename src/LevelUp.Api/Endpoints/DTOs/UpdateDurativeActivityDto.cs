namespace LevelUp.Api.Endpoints.DTOs;

public class UpdateDurativeActivityDto
{
    public string Name { get; init; }
    public DateTimeOffset Date { get; init; }
    public string Duration { get; init; }
    public string Category { get; init; }
}