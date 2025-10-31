using LevelUp.Domain.ManagementContext.ActionActivities;
using Microsoft.EntityFrameworkCore;

namespace LevelUp.Infrastructure.ActionActivities;

public class ActionActivityRepository(LevelUpDbContext dbContext) : IActionActivityRepository
{
    public void Add(ActionActivity entity)
    {
        dbContext.Set<ActionActivity>().Add(entity);
    }

    public async Task<ActionActivity[]> GetAsync()
    {
        return await dbContext.Set<ActionActivity>().ToArrayAsync();
    }

    public async Task<ActionActivity?> GetAsync(Guid id)
    {
        return await dbContext.Set<ActionActivity>().FindAsync(id);
    }

    public void Update(ActionActivity entity)
    {
        dbContext.Set<ActionActivity>().Update(entity);
    }

    public void Delete(ActionActivity entity)
    {
        dbContext.Set<ActionActivity>().Remove(entity);
    }
}