using LevelUp.Application.Common.UseCases;
using LevelUp.Domain.ActionActivities;

namespace LevelUp.Application.ActionActivities.UseCases.CreateActionActivity;

public class CreateActionActivityUseCase(IActionActivityRepository actionActivityRepository)
    : IWriteUseCase<CreateActionActivityRequest, Guid>
{
    public async Task<Guid> HandleAsync(CreateActionActivityRequest request)
    {
        var activity = ActionActivity.Create(request.Name, request.Date, request.Category, request.RewardId);

        actionActivityRepository.Add(activity);

        await Task.CompletedTask;

        return activity.Id;
    }
}