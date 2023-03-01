using FluentValidation;

namespace Api.People.AddPerson
{
    public class AddPersonRequestSocialAccountValidator : AbstractValidator<AddPersonSocialAccountRequest>
    {
        public AddPersonRequestSocialAccountValidator()
        {
            RuleFor(x => x.Type).NotEmpty().WithMessage("Type must not be empty");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address must not be empty");
        }
    }

}
