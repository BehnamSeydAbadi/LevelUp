using LevelUp.Domain.Common;

namespace LevelUp.Domain.Activities;

public interface IActivityRepository : IRepository
{
    void Add(Activity activity);
    Task<Activity[]> GetAsync();
}