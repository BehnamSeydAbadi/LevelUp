namespace LevelUp.Application.Common.UseCases;

public abstract class AbstractUseCaseHandler<TUseCaseDto> where TUseCaseDto : IUseCaseDto
{
    public abstract Task HandleAsync(TUseCaseDto dto);
}