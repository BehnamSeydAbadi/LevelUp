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
using LevelUp.Application.DurativeRewards.Responses;
using LevelUp.Application.DurativeRewards.UseCases.CreateDurativeReward;
using LevelUp.Application.DurativeRewards.UseCases.DeleteDurativeReward;
using LevelUp.Application.DurativeRewards.UseCases.GetDurativeReward;
using LevelUp.Application.DurativeRewards.UseCases.GetDurativeRewards;
using LevelUp.Application.DurativeRewards.UseCases.UpdateDurativeReward;
using Microsoft.Extensions.DependencyInjection;

namespace LevelUp.Application;

public static class ApplicationBootstrapper
{
    public static void Run(IServiceCollection serviceCollection)
    {
        #region DurativeActivities

        serviceCollection
            .AddScoped<IWriteUseCase<CreateDurativeActivityRequest, Guid>, CreateDurativeActivityUseCase>();
        serviceCollection
            .AddScoped<IWriteUseCase<UpdateDurativeActivityRequest, NothingResponse>, UpdateDurativeActivityUseCase>();
        serviceCollection
            .AddScoped<IWriteUseCase<DeleteDurativeActivityRequest, NothingResponse>, DeleteDurativeActivityUseCase>();

        serviceCollection
            .AddScoped<IReadUseCase<GetDurativeActivitiesRequest, DurativeActivityResponse[]>,
                GetDurativeActivitiesUseCase>();

        #endregion

        #region ActionActivities

        serviceCollection
            .AddScoped<IWriteUseCase<CreateActionActivityRequest, Guid>, CreateActionActivityUseCase>();
        serviceCollection
            .AddScoped<IWriteUseCase<UpdateActionActivityRequest, NothingResponse>, UpdateActionActivityUseCase>();
        serviceCollection
            .AddScoped<IWriteUseCase<DeleteActionActivityRequest, NothingResponse>, DeleteActionActivityUseCase>();

        serviceCollection
            .AddScoped<IReadUseCase<GetActionActivitiesRequest, ActionActivityResponse[]>,
                GetActionActivitiesUseCase>();

        #endregion

        #region DurativeRewards

        serviceCollection
            .AddScoped<IWriteUseCase<CreateDurativeRewardRequest, Guid>, CreateDurativeRewardUseCase>();
        serviceCollection
            .AddScoped<IWriteUseCase<UpdateDurativeRewardRequest, NothingResponse>, UpdateDurativeRewardUseCase>();
        serviceCollection
            .AddScoped<IWriteUseCase<DeleteDurativeRewardRequest, NothingResponse>, DeleteDurativeRewardUseCase>();

        serviceCollection
            .AddScoped<IReadUseCase<GetDurativeRewardsRequest, DurativeRewardResponse[]>,
                GetDurativeRewardsUseCase>();
        serviceCollection
            .AddScoped<IReadUseCase<GetDurativeRewardRequest, DurativeRewardResponse?>,
                GetDurativeRewardUseCase>();

        #endregion

        serviceCollection.Decorate(typeof(IWriteUseCase<,>), typeof(SaveChangesUseCaseDecorator<,>));
    }
}