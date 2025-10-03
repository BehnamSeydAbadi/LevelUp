using LevelUp.Application.Activities.UseCases.CreateActivity;
using LevelUp.Application.Activities.UseCases.GetActivities;
using LevelUp.Application.Common.UseCases;
using LevelUp.Application.Common.UseCases.Decorators;
using Microsoft.Extensions.DependencyInjection;

namespace LevelUp.Application;

public static class ApplicationBootstrapper
{
    public static void Run(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IWriteUseCase<CreateActivityRequest, NothingResponse>, CreateActivityUseCase>();

        serviceCollection.AddScoped<IReadUseCase<GetActivitiesRequest, ActivityResponse[]>, GetActivitiesUseCase>();

        serviceCollection.Decorate(typeof(IWriteUseCase<,>), typeof(SaveChangesUseCaseDecorator<,>));
    }
}