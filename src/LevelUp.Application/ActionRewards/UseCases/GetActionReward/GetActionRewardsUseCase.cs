using LevelUp.Application.Common.UseCases;
using LevelUp.Domain.ManagementContext.ActionRewards;

namespace LevelUp.Application.ActionRewards.UseCases.GetActionReward;

public class GetActionRewardsUseCase(IActionRewardRepository actionRewardRepository)
    : IReadUseCase<GetActionRewardsRequest, ActionRewardResponse[]>
{
    public async Task<ActionRewardResponse[]> HandleAsync(GetActionRewardsRequest request)
    {
        var entities = await actionRewardRepository.GetAsync();
        return entities.Select(ActionRewardResponse.Map).ToArray();
    }
}