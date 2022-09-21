using Microsoft.EntityFrameworkCore;
using Neobank.Test.Infrastructure.Persistance.Entities;
using System.Reflection;

namespace Neobank.Test.Infrastructure.Persistance
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<WatchlistItemEntity> Films { get; set; }
        public DbSet<WatchlistEntity> Watchlists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}
