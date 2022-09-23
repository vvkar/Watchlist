using FluentValidation;
using Neobank.Test.API.Validation.Validators;

namespace Neobank.Test.API.DI
{
    public static class ValidatorsInjection
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<GetFilmsRequestValidator>();
        }
    }
}
