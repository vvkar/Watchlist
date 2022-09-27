using FluentValidation;
using Watchlist.API.Models.Requests;
using Watchlist.API.Validation.Validators.Common;

namespace Watchlist.API.Validation.Validators
{
    public class ChangeFilmStatusRequestValidator : AbstractValidator<ChangeFilmStatusRequest>
    {
        public ChangeFilmStatusRequestValidator()
        {
            RuleFor(x => x.UserId).UserId();
            RuleFor(x => x.FilmId).FilmId();
            RuleFor(x => x.IsWatched).NotNull();
        }
    }
}
