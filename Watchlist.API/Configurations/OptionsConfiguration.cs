using Watchlist.Domain.Core.Options;

namespace Watchlist.API.Configurations
{
    public static class OptionsConfiguration
    {
        public static void ConfigureCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FilmSearchServiceOptions>(FilmSearchServiceOptions.IMDB,
                 configuration.GetSection($"{FilmSearchServiceOptions.Section}:{FilmSearchServiceOptions.IMDB}"));

            services.Configure<SmtpOptions>(configuration.GetSection($"{SmtpOptions.SMTP}"));
            services.Configure<PromotionOptions>(configuration.GetSection($"{PromotionOptions.Promotion}"));
        }
    }
}
