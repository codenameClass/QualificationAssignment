namespace Api.People.AddPerson
{
    public record AddPersonResponse
    (
        Guid id,
        string FirstName,
        string LastName,
        List<string> SocialSkills,
        List<AddPersonSocialAccountResponse> SocialAccounts
    );
}
