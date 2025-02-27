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
        builder.Property(b => b.Comment);
        builder.Property(b => b.CreationDate);
        builder.Property(b => b.isComplete);
    }
}