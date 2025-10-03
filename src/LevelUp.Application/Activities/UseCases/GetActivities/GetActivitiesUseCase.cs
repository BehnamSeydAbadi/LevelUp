using LevelUp.Application.Common.UseCases;
using LevelUp.Domain.Activities;

namespace LevelUp.Application.Activities.UseCases.GetActivities;

public class GetActivitiesUseCase(IActivityRepository activityRepository)
    : IReadUseCase<GetActivitiesRequest, ActivityResponse[]>
{
    public async Task<ActivityResponse[]> HandleAsync(GetActivitiesRequest request)
    {
        var entities = await activityRepository.GetAsync();
        return entities.Select(ActivityResponse.Map).ToArray();
    }
}