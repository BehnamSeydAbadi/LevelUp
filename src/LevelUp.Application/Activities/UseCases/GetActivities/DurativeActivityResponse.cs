using LevelUp.Domain.DurativeActivities;

namespace LevelUp.Application.Activities.UseCases.GetActivities;

public class DurativeActivityResponse
{
    public static DurativeActivityResponse Map(DurativeActivity entity)
    {
        return new DurativeActivityResponse
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