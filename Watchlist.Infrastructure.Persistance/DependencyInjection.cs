using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Watchlist.Domain.Interfaces.Repositories.Read;
using Watchlist.Domain.Interfaces.Repositories.Write;
using Watchlist.Infrastructure.Persistance.Repositories.Read;
using Watchlist.Infrastructure.Persistance.Repositories.Write;

namespace Watchlist.Infrastructure.Persistance
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
            services.AddScoped<IWatchlistItemReadRepository, WatchlistItemReadRepository>();
            services.AddScoped<IWatchlistItemWriteRepository, WatchlistItemWriteRepository>();
        }
    }
}
