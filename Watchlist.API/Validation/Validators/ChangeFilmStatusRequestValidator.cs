using FluentValidation;
using Neobank.Test.API.Models.Requests;

namespace Neobank.Test.API.Validation.Validators
{
    public class ChangeFilmStatusRequestValidator : AbstractValidator<ChangeFilmStatusRequest>
    {
        public ChangeFilmStatusRequestValidator()
        {
            RuleFor(x => x.UserId).UserId();
            RuleFor(x => x.FilmId).FilmId();
        }
    }
}
