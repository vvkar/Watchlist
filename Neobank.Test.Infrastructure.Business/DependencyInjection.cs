using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Neobank.Test.Domain.Interfaces.Services;
using Neobank.Test.Infrastructure.Business.Services;

namespace Neobank.Test.Infrastructure.Business
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
