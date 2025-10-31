using LevelUp.Application.Common.UseCases;
using LevelUp.Domain.ManagementContext.DurativeActivities;

namespace LevelUp.Application.DurativeActivities.UseCases.CreateDurativeActivity;

public class CreateDurativeActivityUseCase(IDurativeActivityRepository durativeActivityRepository)
    : IWriteUseCase<CreateDurativeActivityRequest, Guid>
{
    public async Task<Guid> HandleAsync(CreateDurativeActivityRequest request)
    {
        var activity = DurativeActivity.Create(request.Name, request.Date, request.Duration, request.Category);

        durativeActivityRepository.Add(activity);

        await Task.CompletedTask;

        return activity.Id;
    }
}