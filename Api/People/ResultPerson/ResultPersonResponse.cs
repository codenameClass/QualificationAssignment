namespace Api.People.ResultPerson
{
    public record ResultPersonResponse
    (
        Guid id,
        string Firstname,
        string Lastname,
        List<string> SocialSkills,
        List<ResultPersonSocialAccountResponse> SocialAccounts
    );
}
