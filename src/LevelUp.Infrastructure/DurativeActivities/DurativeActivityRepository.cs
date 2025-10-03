using LevelUp.Domain.DurativeActivities;
using Microsoft.EntityFrameworkCore;

namespace LevelUp.Infrastructure.DurativeActivities;

internal class DurativeActivityRepository(LevelUpDbContext dbContext) : IDurativeActivityRepository
{
    public void Add(DurativeActivity durativeActivity)
    {
        dbContext.Set<DurativeActivity>().Add(durativeActivity);
    }

    public async Task<DurativeActivity[]> GetAsync()
    {
        return await dbContext.Set<DurativeActivity>().AsNoTracking().ToArrayAsync();
    }
}