namespace LevelUp.Api.Endpoints.Activities.DTOs;

public class UpdateActionActivityDto
{
    public string Name { get; init; }
    public DateTimeOffset Date { get; init; }
    public string Category { get; init; }
}