using LevelUp.Infrastructure.DurativeActivities;
using Microsoft.EntityFrameworkCore;

namespace LevelUp.Infrastructure;

public class LevelUpDbContext(DbContextOptions<LevelUpDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DurativeActivityConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}