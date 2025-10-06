namespace LevelUp.Application.ActionActivities.UseCases.CreateActionActivity;

public class CreateActionActivityRequest
{
    public string Name { get; set; }
    public DateTimeOffset Date { get; set; }
    public string Category { get; set; }
}