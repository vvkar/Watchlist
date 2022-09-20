using Microsoft.EntityFrameworkCore;
using Neobank.Test.Infrastructure.Persistance.Entities;
using System.Reflection;

namespace Neobank.Test.Infrastructure.Persistance
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {

        }

        public DbSet<FilmEntity> Films { get; set; }
        public DbSet<WatchlistEntity> Watchlists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}
