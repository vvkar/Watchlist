using FluentValidation;
using System.Text.RegularExpressions;

namespace Watchlist.API.Validation.Validators.Common
{
    public static class CommonValidationRules
    {
        public static IRuleBuilderOptions<T, string> FilmId<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.NotNull().Matches(new Regex(@"tt\d{7}")).WithMessage("FilmId should match pattern: tt1234567");
        }

        public static IRuleBuilderOptions<T, Guid> UserId<T>(this IRuleBuilder<T, Guid> ruleBuilder)
        {
            return ruleBuilder.NotNull().NotEmpty().WithMessage("UserId should not be empty");
        }
    }
}
