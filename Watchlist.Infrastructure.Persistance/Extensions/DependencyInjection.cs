using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Watchlist.Domain.Interfaces.Repositories;
using Watchlist.Infrastructure.Persistance.Repositories;

namespace Watchlist.Infrastructure.Persistance.Extensions
{
    public static class DependencyInjection
    {
        public static void AddDataContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString,
                    opts => opts.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWatchlistItemRepository, WatchlistItemRepository>();
        }
    }
}
