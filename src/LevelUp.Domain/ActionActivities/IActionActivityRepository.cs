using LevelUp.Domain.Common;

namespace LevelUp.Domain.ActionActivities;

public interface IActionActivityRepository : IRepository
{
    void Add(ActionActivity entity);
    Task<ActionActivity[]> GetAsync();
    Task<ActionActivity?> GetAsync(Guid id);
    void Update(ActionActivity entity);
    void Delete(ActionActivity entity);
}