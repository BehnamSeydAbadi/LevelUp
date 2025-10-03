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
        serviceCollection.AddScoped<IUseCase<CreateActivityRequest, NothingResponse>, CreateActivityUseCase>();

        serviceCollection.AddScoped<IUseCase<GetActivitiesRequest, ActivityResponse[]>, GetActivitiesUseCase>();

        serviceCollection.Decorate(typeof(IUseCase<,>), typeof(SaveChangesUseCaseDecorator<,>));
    }
}