using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchlist.Infrastructure.Persistance.Entities;

namespace Watchlist.Infrastructure.Persistance.Configurations
{
    public class WatchlistItemConfiguration : IEntityTypeConfiguration<WatchlistItemEntity>
    {
        public void Configure(EntityTypeBuilder<WatchlistItemEntity> builder)
        {
            builder.HasKey(f => new { f.Id, f.UserId });

            builder.Property(f => f.IsWatched)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(f => f.Title).HasMaxLength(50);
        }
    }
}
