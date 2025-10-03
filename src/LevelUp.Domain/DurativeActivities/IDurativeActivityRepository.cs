using LevelUp.Domain.Common;

namespace LevelUp.Domain.DurativeActivities;

public interface IDurativeActivityRepository : IRepository
{
    void Add(DurativeActivity durativeActivity);
    Task<DurativeActivity[]> GetAsync();
}