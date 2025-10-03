using LevelUp.Domain.Activities;
using Microsoft.EntityFrameworkCore;

namespace LevelUp.Infrastructure.Activities;

public class ActivityRepository(LevelUpDbContext dbContext) : IActivityRepository
{
    public void Add(Activity activity)
    {
        dbContext.Set<Activity>().Add(activity);
    }

    public async Task<Activity[]> GetAsync()
    {
        return await dbContext.Set<Activity>().AsNoTracking().ToArrayAsync();
    }
}