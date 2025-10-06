using LevelUp.Domain.ActionActivities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LevelUp.Infrastructure.ActionActivities;

public class ActionActivityConfiguration : IEntityTypeConfiguration<ActionActivity>
{
    public void Configure(EntityTypeBuilder<ActionActivity> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Name).HasMaxLength(128).IsRequired();
        builder.Property(a => a.Date).IsRequired();
        builder.Property(a => a.Category).IsRequired();
    }
}