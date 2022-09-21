using Neobank.Test.Infrastructure.Business.Options;

namespace Neobank.Test.API.Configurations
{
    public static class OptionsConfiguration
    {
        public static void ConfigureCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FilmSearchServiceOptions>(FilmSearchServiceOptions.IMDB,
                 configuration.GetSection($"{FilmSearchServiceOptions.Section}:{FilmSearchServiceOptions.IMDB}"));
        }
    }
}
