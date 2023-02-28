namespace Api.People.ResultPerson
{
    public record ResultPersonResponse
    (
        string Firstname,
        string Lastname,
        List<string> SocialSkills,
        List<ResultPersonSocialAccountResponse> SocialAccounts
    );
}
