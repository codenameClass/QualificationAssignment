namespace Api.People.ResultPerson
{
    public record ResultPersonResponse
    (
        string FirstName,
        string LastName,
        List<string> SocialSkills,
        List<ResultPersonSocialAccountResponse> SocialAccounts
    );
}
