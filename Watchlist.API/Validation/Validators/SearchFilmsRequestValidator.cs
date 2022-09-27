using FluentValidation;
using Watchlist.API.Models.Requests;

namespace Watchlist.API.Validation.Validators
{
    public class SearchFilmsRequestValidator : AbstractValidator<SearchFilmsRequest>
    {
        public SearchFilmsRequestValidator()
        {
            RuleFor(r => r.Title).MaximumLength(50).NotEmpty();
        }
    }
}
