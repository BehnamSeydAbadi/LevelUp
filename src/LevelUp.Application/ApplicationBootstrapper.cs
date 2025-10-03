using LevelUp.Application.Common.UseCases;
using LevelUp.Application.Common.UseCases.Decorators;
using LevelUp.Application.DurativeActivities.UseCases.CreateDurativeActivity;
using LevelUp.Application.DurativeActivities.UseCases.GetDurativeActivities;
using LevelUp.Application.DurativeActivities.UseCases.UpdateDurativeActivity;
using Microsoft.Extensions.DependencyInjection;

namespace LevelUp.Application;

public static class ApplicationBootstrapper
{
    public static void Run(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IWriteUseCase<CreateDurativeActivityRequest, Guid>, CreateDurativeActivityUseCase>();
        serviceCollection
            .AddScoped<IWriteUseCase<UpdateDurativeActivityRequest, NothingResponse>, UpdateDurativeActivityUseCase>();

        serviceCollection
            .AddScoped<IReadUseCase<GetDurativeActivitiesRequest, DurativeActivityResponse[]>,
                GetDurativeActivitiesUseCase>();

        serviceCollection.Decorate(typeof(IWriteUseCase<,>), typeof(SaveChangesUseCaseDecorator<,>));
    }
}