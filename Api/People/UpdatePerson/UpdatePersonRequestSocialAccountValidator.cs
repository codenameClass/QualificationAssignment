using Api.People.AddPerson;
using FluentValidation;
using FluentValidation.Validators;

namespace Api.People.UpdatePerson
{
    public class UpdatePersonRequestSocialAccountValidator : AbstractValidator<UpdatePersonSocialAccountRequest>
    {
        public UpdatePersonRequestSocialAccountValidator()
        {
            RuleFor(x => x.Type).NotEmpty().WithMessage("Type must not be empty");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address must not be empty"); ;
        }
    }
}