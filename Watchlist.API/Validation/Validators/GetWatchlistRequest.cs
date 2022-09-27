using FluentValidation;
using Watchlist.API.Models.Requests;
using Watchlist.API.Validation.Validators.Common;

namespace Watchlist.API.Validation.Validators
{
    public class GetWatchlistRequestValidator : AbstractValidator<GetWatchlistRequest>
    {
        public GetWatchlistRequestValidator()
        {
            RuleFor(r => r.UserId).UserId();
        }
    }
}
