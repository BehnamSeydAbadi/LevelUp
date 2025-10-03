using LevelUp.Infrastructure.Activities;
using Microsoft.EntityFrameworkCore;

namespace LevelUp.Infrastructure;

public class LevelUpDbContext(DbContextOptions<LevelUpDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ActivityConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}