using LevelUp.Application.Common.UseCases;
using LevelUp.Application.DurativeActivities.Exceptions;
using LevelUp.Domain.ManagementContext.DurativeActivities;

namespace LevelUp.Application.DurativeActivities.UseCases.DeleteDurativeActivity;

public class DeleteDurativeActivityUseCase(
    IDurativeActivityRepository durativeActivityRepository
) : IWriteUseCase<DeleteDurativeActivityRequest, NothingResponse>
{
    public async Task<NothingResponse> HandleAsync(DeleteDurativeActivityRequest request)
    {
        var entity = await durativeActivityRepository.GetAsync(request.Id);

        if (entity is null) throw new DurativeActivityNotFoundException();

        durativeActivityRepository.Delete(entity);

        return NothingResponse.Value;
    }
}