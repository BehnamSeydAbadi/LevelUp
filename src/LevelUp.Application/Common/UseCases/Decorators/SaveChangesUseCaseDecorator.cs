namespace LevelUp.Application.Common.UseCases.Decorators;

public class SaveChangesUseCaseDecorator<TRequest, TResponse>(
    IUseCase<TRequest, TResponse> useCase,
    IUnitOfWork unitOfWork
) : IUseCase<TRequest, TResponse>
{
    public async Task<TResponse> HandleAsync(TRequest request)
    {
        var response = await useCase.HandleAsync(request);

        await unitOfWork.SaveChangesAsync(CancellationToken.None);

        return response;
    }
}