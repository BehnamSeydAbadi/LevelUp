using LevelUp.Application.Common.UseCases;
using LevelUp.Domain.ManagementContext.DurativeActivities;

namespace LevelUp.Application.DurativeActivities.UseCases.GetDurativeActivities;

public class GetDurativeActivitiesUseCase(IDurativeActivityRepository durativeActivityRepository)
    : IReadUseCase<GetDurativeActivitiesRequest, DurativeActivityResponse[]>
{
    public async Task<DurativeActivityResponse[]> HandleAsync(GetDurativeActivitiesRequest request)
    {
        var entities = await durativeActivityRepository.GetAsync();
        return entities.Select(DurativeActivityResponse.Map).ToArray();
    }
}