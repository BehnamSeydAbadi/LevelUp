namespace LevelUp.Application.DurativeActivities.UseCases.CreateDurativeActivity;

public record CreateDurativeActivityRequest
{
    public string Name { get; init; }
    public DateTimeOffset Date { get; init; }
    public TimeSpan Duration { get; init; }
    public string Category { get; init; }
}