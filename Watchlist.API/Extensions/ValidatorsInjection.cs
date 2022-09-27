using FluentValidation;
using System.Reflection;

namespace Watchlist.API.Extensions
{
    public static class ValidatorsInjection
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
