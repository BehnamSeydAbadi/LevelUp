using LevelUp.Application.Common.UseCases;
using LevelUp.Domain.DurativeActivities;

namespace LevelUp.Application.DurativeActivities.UseCases.UpdateDurativeActivity;

public class UpdateDurativeActivityUseCase(
    IDurativeActivityRepository durativeActivityRepository
) : IWriteUseCase<UpdateDurativeActivityRequest, NothingResponse>
{
    public async Task<NothingResponse> HandleAsync(UpdateDurativeActivityRequest request)
    {
        var entity = await durativeActivityRepository.GetAsync(request.Id);

        if (entity is null) throw new DurativeActivityNotFoundException();

        entity.Update(request.Name, request.Date, request.Duration, request.Category);

        durativeActivityRepository.Update(entity);

        return NothingResponse.Value;
    }
}