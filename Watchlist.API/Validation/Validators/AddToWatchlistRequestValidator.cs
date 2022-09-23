using FluentValidation;
using Neobank.Test.API.Models.Requests;
using System.Text.RegularExpressions;

namespace Neobank.Test.API.Validation.Validators
{
    public class AddToWatchlistRequestValidator : AbstractValidator<AddToWatchlistRequest>
    {
        public AddToWatchlistRequestValidator()
        {
            RuleFor(r => r.UserId).UserId();
            RuleFor(r => r.FilmId).FilmId();
        }
    }
}
