using LevelUp.Domain.Activities;

namespace LevelUp.Application.Activities.UseCases.GetActivities;

public class ActivityResponse
{
    public static ActivityResponse Map(Activity entity)
    {
        return new ActivityResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Date = entity.Date,
            Duration = entity.Duration.ToString("c"),
            Category = entity.Category
        };
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTimeOffset Date { get; set; }
    public string Duration { get; set; }
    public string Category { get; set; }
}