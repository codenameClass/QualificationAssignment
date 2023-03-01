namespace Api.People.GetAllPeople
{
    public record GetAllPersonResponse
    (
        Guid id,
        string FirstName,
        string LastName,
        List<string> SocialSkills,
        List<GetAllPersonSocialAccountResponse> SocialAccounts
    );
}
