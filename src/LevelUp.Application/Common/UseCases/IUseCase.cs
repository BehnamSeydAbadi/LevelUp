namespace LevelUp.Application.Common.UseCases;

public interface IUseCase<in TRequest, TResponse>
{
    Task<TResponse> HandleAsync(TRequest request);
}

public interface IWriteUseCase<in TRequest, TResponse> : IUseCase<TRequest, TResponse>;
public interface IReadUseCase<in TRequest, TResponse> : IUseCase<TRequest, TResponse>;