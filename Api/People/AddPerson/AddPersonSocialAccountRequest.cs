using System.ComponentModel.DataAnnotations;

namespace Api.People.AddPerson
{
    public record AddPersonSocialAccountRequest
    (
        string Type,
        string Address
    );
}