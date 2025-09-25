using LevelUp.Application.Common.UseCases;
using LevelUp.Domain.Activities;
using LevelUp.Domain.Common;

namespace LevelUp.Application.Activities.UseCases.CreateActivity;

public class CreateActivityUseCase(IEventPublisher eventPublisher) : AbstractUseCaseHandler<CreateActivityUseCaseDto>
{
    public override async Task HandleAsync(CreateActivityUseCaseDto dto)
    {
        var activity = Activity.Create(dto.Name, dto.Date, dto.Duration, dto.Category);

        await eventPublisher.PublishAsync(activity.GetDomainEvents().ToArray());
    }
}