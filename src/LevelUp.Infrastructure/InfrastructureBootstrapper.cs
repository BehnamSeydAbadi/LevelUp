using LevelUp.Application.Common;
using LevelUp.Domain.ActionActivities;
using LevelUp.Domain.ActionRewards;
using LevelUp.Domain.DurativeActivities;
using LevelUp.Domain.DurativeRewards;
using LevelUp.Infrastructure.ActionActivities;
using LevelUp.Infrastructure.ActionRewards;
using LevelUp.Infrastructure.Common;
using LevelUp.Infrastructure.DurativeActivities;
using LevelUp.Infrastructure.DurativeRewards;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LevelUp.Infrastructure;

public static class InfrastructureBootstrapper
{
    public static void Run(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LevelUpDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        );

        services.AddScoped<IDurativeActivityRepository, DurativeActivityRepository>();
        services.AddScoped<IActionActivityRepository, ActionActivityRepository>();
        services.AddScoped<IDurativeRewardRepository, DurativeRewardRepository>();
        services.AddScoped<IActionRewardRepository, ActionRewardRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void ApplyMigrations(IApplicationBuilder app)
    {
        var serviceScope = app.ApplicationServices.CreateScope();
        var dbContext = serviceScope.ServiceProvider.GetRequiredService<LevelUpDbContext>();
        dbContext.Database.Migrate();
        dbContext.Database.CloseConnection();
        serviceScope.Dispose();
    }
}