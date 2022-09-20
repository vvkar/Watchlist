using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Neobank.Test.Infrastructure.Persistance
{
    public static class DependencyInjection
    {
        public static void AddDataContext(this IServiceCollection  services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppContext>(options =>
                options.UseSqlServer(connectionString, 
                    opts => opts.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)));
        }
    }
}
