using LevelUp.Domain.ActionRewards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LevelUp.Infrastructure.ActionRewards;

public class ActionRewardConfiguration : IEntityTypeConfiguration<ActionReward>
{
    public void Configure(EntityTypeBuilder<ActionReward> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name).HasMaxLength(128).IsRequired();
        builder.Property(r => r.Date).IsRequired();
        builder.Property(r => r.Category).IsRequired();
    }
}