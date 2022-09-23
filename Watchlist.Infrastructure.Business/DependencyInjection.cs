using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Watchlist.Domain.Interfaces.Services;
using Watchlist.Infrastructure.Business.Services;

namespace Watchlist.Infrastructure.Business
{
    public static class DependencyInjection
    {
        public static void AddApplications(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IFilmSearchService, ImdbSearchService>();

            //UNDONE: consider factory
            services.AddHttpClient<IFilmSearchService, ImdbSearchService>();
        }
    }
}
