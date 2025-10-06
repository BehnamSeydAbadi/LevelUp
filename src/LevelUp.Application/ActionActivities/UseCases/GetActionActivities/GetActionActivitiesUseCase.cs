using LevelUp.Application.Common.UseCases;
using LevelUp.Domain.ActionActivities;

namespace LevelUp.Application.ActionActivities.UseCases.GetActionActivities;

public class GetActionActivitiesUseCase(IActionActivityRepository actionActivityRepository)
    : IReadUseCase<GetActionActivitiesRequest, ActionActivityResponse[]>
{
    public async Task<ActionActivityResponse[]> HandleAsync(GetActionActivitiesRequest request)
    {
        var entities = await actionActivityRepository.GetAsync();
        return entities.Select(ActionActivityResponse.Map).ToArray();
    }
}