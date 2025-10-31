using LevelUp.Domain.Common;

namespace LevelUp.Domain.ManagementContext.DurativeActivities;

public interface IDurativeActivityRepository : IRepository
{
    void Add(DurativeActivity entity);
    Task<DurativeActivity[]> GetAsync();
    Task<DurativeActivity?> GetAsync(Guid id);
    void Update(DurativeActivity entity);
    void Delete(DurativeActivity entity);
}