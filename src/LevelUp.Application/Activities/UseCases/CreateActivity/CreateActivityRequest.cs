namespace LevelUp.Application.Activities.UseCases.CreateActivity;

public record CreateActivityRequest
{
    public string Name { get; init; }
    public DateTimeOffset Date { get; init; }
    public TimeSpan Duration { get; init; }
    public string Category { get; init; }
}