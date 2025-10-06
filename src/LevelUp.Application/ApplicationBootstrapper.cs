using LevelUp.Application.ActionActivities.UseCases.CreateActionActivity;
using LevelUp.Application.ActionActivities.UseCases.DeleteActionActivity;
using LevelUp.Application.ActionActivities.UseCases.GetActionActivities;
using LevelUp.Application.ActionActivities.UseCases.UpdateActionActivity;
using LevelUp.Application.Common.UseCases;
using LevelUp.Application.Common.UseCases.Decorators;
using LevelUp.Application.DurativeActivities.UseCases.CreateDurativeActivity;
using LevelUp.Application.DurativeActivities.UseCases.DeleteDurativeActivity;
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
            .AddScoped<IWriteUseCase<DeleteDurativeActivityRequest, NothingResponse>, DeleteDurativeActivityUseCase>();
        
        serviceCollection
            .AddScoped<IWriteUseCase<CreateActionActivityRequest, Guid>, CreateActionActivityUseCase>();
        serviceCollection
            .AddScoped<IWriteUseCase<UpdateActionActivityRequest, NothingResponse>, UpdateActionActivityUseCase>();
        serviceCollection
            .AddScoped<IWriteUseCase<DeleteActionActivityRequest, NothingResponse>, DeleteActionActivityUseCase>();

        serviceCollection
            .AddScoped<IReadUseCase<GetDurativeActivitiesRequest, DurativeActivityResponse[]>,
                GetDurativeActivitiesUseCase>();
        
        serviceCollection
            .AddScoped<IReadUseCase<GetActionActivitiesRequest, ActionActivityResponse[]>,
                GetActionActivitiesUseCase>();

        serviceCollection.Decorate(typeof(IWriteUseCase<,>), typeof(SaveChangesUseCaseDecorator<,>));
    }
}