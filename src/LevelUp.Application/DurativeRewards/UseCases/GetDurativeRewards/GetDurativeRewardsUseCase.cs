using LevelUp.Application.Common.UseCases;
using LevelUp.Domain.DurativeRewards;

namespace LevelUp.Application.DurativeRewards.UseCases.GetDurativeRewards;

public class GetDurativeRewardsUseCase(IDurativeRewardRepository durativeRewardRepository)
    : IReadUseCase<GetDurativeRewardsRequest, DurativeRewardResponse[]>
{
    public async Task<DurativeRewardResponse[]> HandleAsync(GetDurativeRewardsRequest request)
    {
        var entities = await durativeRewardRepository.GetAsync();
        return entities.Select(DurativeRewardResponse.Map).ToArray();
    }
}