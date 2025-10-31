using LevelUp.Domain.ManagementContext.DurativeRewards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LevelUp.Infrastructure.DurativeRewards;

public class DurativeRewardConfiguration : IEntityTypeConfiguration<DurativeReward>
{
    public void Configure(EntityTypeBuilder<DurativeReward> builder)
    {
        builder.HasKey(rr => rr.Id);

        builder.Property(rr => rr.Name).HasMaxLength(128).IsRequired();
        builder.Property(rr => rr.Duration).IsRequired();
        builder.Property(rr => rr.Category).IsRequired();
        builder.Property(rr => rr.ExpireDate).IsRequired();
    }
}