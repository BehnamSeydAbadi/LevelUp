using LevelUp.Domain.ManagementContext.ActionRewards;
using Microsoft.EntityFrameworkCore;

namespace LevelUp.Infrastructure.ActionRewards;

public class ActionRewardRepository(LevelUpDbContext dbContext) : IActionRewardRepository
{
    public void Add(ActionReward entity)
    {
        dbContext.Set<ActionReward>().Add(entity);
    }

    public async Task<ActionReward[]> GetAsync()
    {
        return await dbContext.Set<ActionReward>().ToArrayAsync();
    }

    public async Task<ActionReward?> GetAsync(Guid id)
    {
        return await dbContext.Set<ActionReward>().FindAsync(id);
    }

    public void Update(ActionReward entity)
    {
        dbContext.Set<ActionReward>().Update(entity);
    }

    public void Delete(ActionReward entity)
    {
        dbContext.Set<ActionReward>().Remove(entity);
    }
}