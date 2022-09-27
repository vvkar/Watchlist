using FluentValidation;
using System.Reflection;
using Watchlist.API.Validation.Validators;

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
