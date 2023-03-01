using Api.People.AddPerson;
using FluentValidation;

namespace Api.People.UpdatePerson
{
    public class UpdatePersonRequestValidator : AbstractValidator<UpdatePersonRequest>
    {
        public UpdatePersonRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id must not be empty");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName must not be empty");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName must not be empty");
            RuleFor(x => x.SocialSkills).Must(x => x != null && x.Any()).WithMessage("SocialSkills must contain at least one item.");
            RuleFor(x => x.SocialAccounts).Must(x => x != null && x.Any()).WithMessage("SocialAccounts must contain at least one item.");
            RuleForEach(x => x.SocialAccounts).SetValidator(new UpdatePersonRequestSocialAccountValidator());
        }
    }
}