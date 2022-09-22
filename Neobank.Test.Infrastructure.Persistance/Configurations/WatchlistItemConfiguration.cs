using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neobank.Test.Infrastructure.Persistance.Entities;

namespace Neobank.Test.Infrastructure.Persistance.Configurations
{
    public class WatchlistItemConfiguration : IEntityTypeConfiguration<WatchlistItemEntity>
    {
        public void Configure(EntityTypeBuilder<WatchlistItemEntity> builder)
        {
            builder.HasKey(f => new {f.Id, f.UserId});

            builder.Property(f => f.IsWatched)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(f => f.Title).HasMaxLength(50);
        }
    }
}
