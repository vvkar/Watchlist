using FluentValidation;
using System.Text.RegularExpressions;
using Watchlist.API.Models.Requests;
using Watchlist.API.Validation.Validators.Common;

namespace Watchlist.API.Validation.Validators
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
