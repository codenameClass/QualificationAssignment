using Api.People.GetAllPeople;

namespace Api.People.GetPersonById
{
    public record GetPersonByIdResponse
    (
        Guid id,
        string FirstName,
        string LastName,
        List<string> SocialSkills,
        List<GetPersonByIdSocialAccountResponse> SocialAccounts
    );
}
