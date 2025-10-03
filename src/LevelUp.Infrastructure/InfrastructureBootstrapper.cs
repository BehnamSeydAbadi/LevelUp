using LevelUp.Application.Common;
using LevelUp.Domain.Activities;
using LevelUp.Infrastructure.Activities;
using LevelUp.Infrastructure.Common;
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

        services.AddScoped<IActivityRepository, ActivityRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}