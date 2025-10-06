using LevelUp.Domain.ActionActivities;

namespace LevelUp.Application.ActionActivities.UseCases.GetActionActivities;

public class ActionActivityResponse
{
    public static ActionActivityResponse Map(ActionActivity entity)
    {
        return new ActionActivityResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Date = entity.Date,
            Category = entity.Category
        };
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTimeOffset Date { get; set; }
    public string Category { get; set; }
}