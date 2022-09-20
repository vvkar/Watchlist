using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neobank.Test.Infrastructure.Persistance.Entities;

namespace Neobank.Test.Infrastructure.Persistance.Configurations
{
    public class WatchlistConfiguration : IEntityTypeConfiguration<WatchlistEntity>
    {
        public void Configure(EntityTypeBuilder<WatchlistEntity> builder)
        {
            builder.HasKey(wl => wl.Id);

            builder.HasIndex(wl => wl.UserId);
        }
    }
}
