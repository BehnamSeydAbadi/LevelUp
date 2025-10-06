using LevelUp.Application.ActionActivities.Exceptions;
using LevelUp.Application.Common.UseCases;
using LevelUp.Domain.ActionActivities;

namespace LevelUp.Application.ActionActivities.UseCases.DeleteActionActivity;

public class DeleteActionActivityUseCase(
    IActionActivityRepository actionActivityRepository
) : IWriteUseCase<DeleteActionActivityRequest, NothingResponse>
{
    public async Task<NothingResponse> HandleAsync(DeleteActionActivityRequest request)
    {
        var entity = await actionActivityRepository.GetAsync(request.Id);

        if (entity is null) throw new ActionActivityNotFoundException();

        actionActivityRepository.Delete(entity);

        return NothingResponse.Value;
    }
}