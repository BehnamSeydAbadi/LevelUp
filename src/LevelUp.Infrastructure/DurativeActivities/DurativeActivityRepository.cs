using LevelUp.Domain.DurativeActivities;
using Microsoft.EntityFrameworkCore;

namespace LevelUp.Infrastructure.DurativeActivities;

internal class DurativeActivityRepository(LevelUpDbContext dbContext) : IDurativeActivityRepository
{
    public void Add(DurativeActivity entity)
    {
        dbContext.Set<DurativeActivity>().Add(entity);
    }

    public async Task<DurativeActivity[]> GetAsync()
    {
        return await dbContext.Set<DurativeActivity>().ToArrayAsync();
    }

    public async Task<DurativeActivity?> GetAsync(Guid id)
    {
        return await dbContext.Set<DurativeActivity>().FindAsync(id);
    }

    public void Update(DurativeActivity entity)
    {
        dbContext.Set<DurativeActivity>().Update(entity);
    }

    public void Delete(DurativeActivity entity)
    {
        dbContext.Set<DurativeActivity>().Remove(entity);
    }
}