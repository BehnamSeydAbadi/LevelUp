using LevelUp.Application.ActionRewards.Exceptions;
using LevelUp.Application.Common.UseCases;
using LevelUp.Domain.ManagementContext.ActionRewards;

namespace LevelUp.Application.ActionRewards.UseCases.DeleteActionReward;

public class DeleteActionRewardUseCase(
    IActionRewardRepository actionRewardRepository
) : IWriteUseCase<DeleteActionRewardRequest, NothingResponse>
{
    public async Task<NothingResponse> HandleAsync(DeleteActionRewardRequest request)
    {
        var entity = await actionRewardRepository.GetAsync(request.Id);

        if (entity is null) throw new ActionRewardNotFoundException();

        actionRewardRepository.Delete(entity);

        return NothingResponse.Value;
    }
}