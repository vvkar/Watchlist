using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neobank.Test.Infrastructure.Persistance.Entities;

namespace Neobank.Test.Infrastructure.Persistance.Configurations
{
    public class FilmConfiguration : IEntityTypeConfiguration<WatchlistItemEntity>
    {
        public void Configure(EntityTypeBuilder<WatchlistItemEntity> builder)
        {
            builder.HasKey(f => new {f.Id, f.WatchlistId});

            builder.HasOne(f => f.Watchlist)
                .WithMany(wl => wl.Films);

            builder.Property(f => f.IsWatched)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(f => f.Title).HasMaxLength(50);
        }
    }
}
