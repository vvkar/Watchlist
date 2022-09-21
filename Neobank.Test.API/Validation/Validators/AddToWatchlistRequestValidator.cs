using FluentValidation;
using Neobank.Test.API.Models.Requests;
using System.Text.RegularExpressions;

namespace Neobank.Test.API.Validation.Validators
{
    public class AddToWatchlistRequestValidator : AbstractValidator<AddToWatchlistRequest>
    {
        public AddToWatchlistRequestValidator()
        {
            RuleFor(r => r.UserId).NotEmpty().WithMessage("UserId should not be empty");
            RuleFor(r => r.FilmId).NotNull().Matches(new Regex(@"tt\d{7}"))
                .WithMessage("FilmId should match pattern: tt1234567");
        }
    }
}
