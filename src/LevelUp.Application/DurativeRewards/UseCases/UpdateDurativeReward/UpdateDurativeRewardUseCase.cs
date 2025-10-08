using LevelUp.Application.Common.UseCases;
using LevelUp.Application.DurativeRewards.Exceptions;
using LevelUp.Domain.DurativeRewards;

namespace LevelUp.Application.DurativeRewards.UseCases.UpdateDurativeReward;

public class UpdateDurativeRewardUseCase(IDurativeRewardRepository durativeRewardRepository)
    : IWriteUseCase<UpdateDurativeRewardRequest, NothingResponse>
{
    public async Task<NothingResponse> HandleAsync(UpdateDurativeRewardRequest request)
    {
        var entity = await durativeRewardRepository.GetAsync(request.Id);

        if (entity is null) throw new DurativeRewardNotFoundException();

        entity.Update(request.Name, request.Duration, request.Category, request.ExpireDate);

        durativeRewardRepository.Update(entity);

        return NothingResponse.Value;
    }
}