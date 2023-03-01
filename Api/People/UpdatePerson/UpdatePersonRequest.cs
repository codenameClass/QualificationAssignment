namespace Api.People.UpdatePerson
{
    public record UpdatePersonRequest
    (
        Guid Id,
        string FirstName,
        string LastName,
        List<string> SocialSkills,
        List<UpdatePersonSocialAccountRequest> SocialAccounts
    );
}
