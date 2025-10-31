using LevelUp.Domain.ManagementContext.DurativeRewards;
using Microsoft.EntityFrameworkCore;

namespace LevelUp.Infrastructure.DurativeRewards;

public class DurativeRewardRepository(LevelUpDbContext dbContext) : IDurativeRewardRepository
{
    public void Add(DurativeReward entity)
    {
        dbContext.Set<DurativeReward>().Add(entity);
    }

    public async Task<DurativeReward[]> GetAsync()
    {
        return await dbContext.Set<DurativeReward>().ToArrayAsync();
    }

    public async Task<DurativeReward?> GetAsync(Guid id)
    {
        return await dbContext.Set<DurativeReward>().FindAsync(id);
    }

    public void Update(DurativeReward entity)
    {
        dbContext.Set<DurativeReward>().Update(entity);
    }

    public void Delete(DurativeReward entity)
    {
        dbContext.Set<DurativeReward>().Remove(entity);
    }
}