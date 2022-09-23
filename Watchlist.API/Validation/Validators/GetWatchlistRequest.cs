using FluentValidation;
using Neobank.Test.API.Models.Requests;

namespace Neobank.Test.API.Validation.Validators
{
    public class GetWatchlistRequestValidator : AbstractValidator<GetWatchlistRequest>
    {
        public GetWatchlistRequestValidator()
        {
            RuleFor(r => r.UserId).UserId();
        }
    }
}
