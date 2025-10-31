using LevelUp.Domain.ManagementContext.DurativeActivities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LevelUp.Infrastructure.DurativeActivities;

public class DurativeActivityConfiguration : IEntityTypeConfiguration<DurativeActivity>
{
    public void Configure(EntityTypeBuilder<DurativeActivity> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Name).HasMaxLength(128).IsRequired();
        builder.Property(a => a.Date).IsRequired();
        builder.Property(a => a.Duration).IsRequired();
        builder.Property(a => a.Category).IsRequired();
    }
}