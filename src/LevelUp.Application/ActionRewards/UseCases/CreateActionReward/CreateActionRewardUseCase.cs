using LevelUp.Application.Common.UseCases;
using LevelUp.Domain.ManagementContext.ActionRewards;

namespace LevelUp.Application.ActionRewards.UseCases.CreateActionReward;

public class CreateActionRewardUseCase(IActionRewardRepository actionRewardRepository)
    : IWriteUseCase<CreateActionRewardRequest, Guid>
{
    public async Task<Guid> HandleAsync(CreateActionRewardRequest request)
    {
        var reward = ActionReward.Create(request.Name, request.Date, request.Category);

        actionRewardRepository.Add(reward);

        await Task.CompletedTask;

        return reward.Id;
    }
}