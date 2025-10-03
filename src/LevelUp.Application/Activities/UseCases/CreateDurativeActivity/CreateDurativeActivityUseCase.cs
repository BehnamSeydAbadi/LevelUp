using LevelUp.Application.Common.UseCases;
using LevelUp.Domain.DurativeActivities;

namespace LevelUp.Application.Activities.UseCases.CreateDurativeActivity;

public class CreateDurativeActivityUseCase(IDurativeActivityRepository durativeActivityRepository)
    : IWriteUseCase<CreateDurativeActivityRequest, NothingResponse>
{
    public async Task<NothingResponse> HandleAsync(CreateDurativeActivityRequest request)
    {
        var activity = DurativeActivity.Create(request.Name, request.Date, request.Duration, request.Category);

        durativeActivityRepository.Add(activity);

        await Task.CompletedTask;

        return NothingResponse.Value;
    }
}