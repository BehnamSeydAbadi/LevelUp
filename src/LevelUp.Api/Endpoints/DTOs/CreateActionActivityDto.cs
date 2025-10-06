namespace LevelUp.Api.Endpoints.DTOs;

public class CreateActionActivityDto
{
    public string Name { get; init; }
    public DateTimeOffset Date { get; init; }
    public string Category { get; init; }
}