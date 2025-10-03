namespace LevelUp.Application.DurativeActivities.UseCases.UpdateDurativeActivity;

public class UpdateDurativeActivityRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTimeOffset Date { get; set; }
    public TimeSpan Duration { get; set; }
    public string Category { get; set; }
}