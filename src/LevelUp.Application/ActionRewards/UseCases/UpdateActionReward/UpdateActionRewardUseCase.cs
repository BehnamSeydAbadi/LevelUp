using LevelUp.Application.ActionRewards.Exceptions;
using LevelUp.Application.Common.UseCases;
using LevelUp.Domain.ActionRewards;

namespace LevelUp.Application.ActionRewards.UseCases.UpdateActionReward;

public class UpdateActionRewardUseCase(
    IActionRewardRepository actionRewardRepository
) : IWriteUseCase<UpdateActionRewardRequest, NothingResponse>
{
    public async Task<NothingResponse> HandleAsync(UpdateActionRewardRequest request)
    {
        var entity = await actionRewardRepository.GetAsync(request.Id);

        if (entity is null) throw new ActionRewardNotFoundException();

        entity.Update(request.Name, request.Date, request.Category);

        actionRewardRepository.Update(entity);

        return NothingResponse.Value;
    }
}