using LevelUp.Application.ActionActivities.Exceptions;
using LevelUp.Application.Common.UseCases;
using LevelUp.Domain.ActionActivities;

namespace LevelUp.Application.ActionActivities.UseCases.UpdateActionActivities;

public class UpdateActionActivityUseCase(
    IActionActivityRepository actionActivityRepository
) : IWriteUseCase<UpdateActionActivityRequest, NothingResponse>
{
    public async Task<NothingResponse> HandleAsync(UpdateActionActivityRequest request)
    {
        var entity = await actionActivityRepository.GetAsync(request.Id);

        if (entity is null) throw new ActionActivityNotFoundException();

        entity.Update(request.Name, request.Date, request.Category);

        actionActivityRepository.Update(entity);

        return NothingResponse.Value;
    }
}