using LevelUp.Domain.Activities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LevelUp.Infrastructure.Activities;

public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Name).HasMaxLength(128).IsRequired();
        builder.Property(a => a.Date).IsRequired();
        builder.Property(a => a.Duration).IsRequired();
        builder.Property(a => a.Category).IsRequired();
    }
}