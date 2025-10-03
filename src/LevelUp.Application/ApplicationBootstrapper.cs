using LevelUp.Application.Activities.UseCases.CreateDurativeActivity;
using LevelUp.Application.Activities.UseCases.GetActivities;
using LevelUp.Application.Common.UseCases;
using LevelUp.Application.Common.UseCases.Decorators;
using Microsoft.Extensions.DependencyInjection;

namespace LevelUp.Application;

public static class ApplicationBootstrapper
{
    public static void Run(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IWriteUseCase<CreateDurativeActivityRequest, NothingResponse>, CreateDurativeActivityUseCase>();

        serviceCollection.AddScoped<IReadUseCase<GetDurativeActivitiesRequest, DurativeActivityResponse[]>, GetDurativeActivitiesUseCase>();

        serviceCollection.Decorate(typeof(IWriteUseCase<,>), typeof(SaveChangesUseCaseDecorator<,>));
    }
}