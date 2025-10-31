using LevelUp.Application.Common.UseCases;
using LevelUp.Domain.ManagementContext.DurativeRewards;

namespace LevelUp.Application.DurativeRewards.UseCases.CreateDurativeReward;

public class CreateDurativeRewardUseCase(IDurativeRewardRepository durativeRewardRepository)
    : IWriteUseCase<CreateDurativeRewardRequest, Guid>
{
    public async Task<Guid> HandleAsync(CreateDurativeRewardRequest request)
    {
        var activity = DurativeReward.Create(request.Name, request.Duration, request.Category, request.ExpireDate);

        durativeRewardRepository.Add(activity);

        await Task.CompletedTask;

        return activity.Id;
    }
}