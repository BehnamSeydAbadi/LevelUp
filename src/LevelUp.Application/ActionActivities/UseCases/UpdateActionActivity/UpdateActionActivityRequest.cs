namespace LevelUp.Application.ActionActivities.UseCases.UpdateActionActivity;

public class UpdateActionActivityRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTimeOffset Date { get; set; }
    public string Category { get; set; }
}