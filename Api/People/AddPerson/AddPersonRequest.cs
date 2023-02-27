using Core.Model;

namespace Api.People.AddPerson
{
    public record AddPersonRequest
    (
        string Firstname,
        string Lastname,
        List<string> SocialSkills,
        List<AddPersonSocialAccountRequest> SocialAccounts
    );
}
