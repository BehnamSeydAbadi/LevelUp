namespace LevelUp.Application.Common.UseCases;

public interface IUseCase<in TRequest, TResponse>
{
    Task<TResponse> HandleAsync(TRequest request);
}