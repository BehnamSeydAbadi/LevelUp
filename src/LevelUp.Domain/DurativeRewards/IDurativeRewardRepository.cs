namespace LevelUp.Domain.DurativeRewards;

public interface IDurativeRewardRepository
{
    void Add(DurativeReward entity);
    Task<DurativeReward?> GetAsync(Guid id);
    void Update(DurativeReward entity);
    void Delete(DurativeReward entity);
}