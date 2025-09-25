using LevelUp.Infrastructure.Activities;
using Microsoft.EntityFrameworkCore;

namespace LevelUp.Infrastructure.Persistence;

public class LevelUpDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ActivityConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}