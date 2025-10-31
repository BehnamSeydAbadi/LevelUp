using LevelUp.Application.Common.UseCases;
using LevelUp.Application.DurativeRewards.Exceptions;
using LevelUp.Domain.ManagementContext.DurativeRewards;

namespace LevelUp.Application.DurativeRewards.UseCases.DeleteDurativeReward;

public class DeleteDurativeRewardUseCase(IDurativeRewardRepository durativeRewardRepository)
    : IWriteUseCase<DeleteDurativeRewardRequest, NothingResponse>
{
    public async Task<NothingResponse> HandleAsync(DeleteDurativeRewardRequest request)
    {
        var entity = await durativeRewardRepository.GetAsync(request.Id);

        if (entity is null) throw new DurativeRewardNotFoundException();

        durativeRewardRepository.Delete(entity);

        return NothingResponse.Value;
    }
}