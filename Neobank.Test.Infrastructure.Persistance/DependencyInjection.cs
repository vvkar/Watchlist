using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Neobank.Test.Domain.Interfaces.Repositories.Read;
using Neobank.Test.Domain.Interfaces.Repositories.Write;
using Neobank.Test.Infrastructure.Persistance.Repositories.Read;
using Neobank.Test.Infrastructure.Persistance.Repositories.Write;
using System.Reflection;

namespace Neobank.Test.Infrastructure.Persistance
{
    public static class DependencyInjection
    {
        public static void AddDataContext(this IServiceCollection  services, IConfiguration config)
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
