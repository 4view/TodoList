using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Core.Entities;
using Todo.Core.Models;

namespace Todo.Data.Configuration;

public class ChallengeConfiguration : IEntityTypeConfiguration<ChallengeEntity>
{
    public void Configure(EntityTypeBuilder<ChallengeEntity> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Comment).HasMaxLength(500);
        builder.Property(b => b.CreationDate).IsRequired();
        builder.Property(b => b.isComplete).HasDefaultValue(false).IsRequired();
    }
}