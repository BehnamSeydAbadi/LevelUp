namespace LevelUp.Domain.ManagementContext.DurativeRewards;

public interface IDurativeRewardRepository
{
    void Add(DurativeReward entity);
    Task<DurativeReward?> GetAsync(Guid id);
    Task<DurativeReward[]> GetAsync();
    void Update(DurativeReward entity);
    void Delete(DurativeReward entity);
}