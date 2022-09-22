using FluentValidation;
using Neobank.Test.API.Models.Requests;

namespace Neobank.Test.API.Validation.Validators
{
    public class GetFilmsRequestValidator : AbstractValidator<GetFilmsRequest>
    {
        public GetFilmsRequestValidator()
        {
            RuleFor(r => r.Title).MaximumLength(50).NotEmpty();
        }
    }
}
