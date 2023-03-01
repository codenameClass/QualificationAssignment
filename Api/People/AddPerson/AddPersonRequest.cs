using Core.Model;
using System.ComponentModel.DataAnnotations;

namespace Api.People.AddPerson
{
    public record AddPersonRequest
    (
        string FirstName,
        string LastName,
        List<string> SocialSkills,
        List<AddPersonSocialAccountRequest> SocialAccounts
    );

}
