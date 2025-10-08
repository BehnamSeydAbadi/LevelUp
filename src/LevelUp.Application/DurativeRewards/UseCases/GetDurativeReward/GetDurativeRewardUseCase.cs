using LevelUp.Application.Common.UseCases;
using LevelUp.Application.DurativeRewards.Responses;
using LevelUp.Domain.DurativeRewards;

namespace LevelUp.Application.DurativeRewards.UseCases.GetDurativeReward;

public class GetDurativeRewardUseCase(IDurativeRewardRepository durativeRewardRepository)
    : IReadUseCase<GetDurativeRewardRequest, DurativeRewardResponse?>
{
    public async Task<DurativeRewardResponse?> HandleAsync(GetDurativeRewardRequest request)
    {
        var entity = await durativeRewardRepository.GetAsync(request.Id);
        return entity is null ? null : DurativeRewardResponse.Map(entity!);
    }
}