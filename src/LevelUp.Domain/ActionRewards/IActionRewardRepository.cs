using LevelUp.Domain.Common;

namespace LevelUp.Domain.ActionRewards;

public interface IActionRewardRepository : IRepository
{
    void Add(ActionReward entity);
    Task<ActionReward?> GetAsync(Guid id);
    void Update(ActionReward entity);
}