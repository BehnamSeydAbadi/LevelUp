using LevelUp.Application.Common.UseCases;
using LevelUp.Domain.Activities;

namespace LevelUp.Application.Activities.UseCases.CreateActivity;

public class CreateActivityUseCase(IActivityRepository activityRepository)
    : IUseCase<CreateActivityRequest, NothingResponse>
{
    public async Task<NothingResponse> HandleAsync(CreateActivityRequest request)
    {
        var activity = Activity.Create(request.Name, request.Date, request.Duration, request.Category);

        activityRepository.Add(activity);

        await Task.CompletedTask;

        return NothingResponse.Value;
    }
}