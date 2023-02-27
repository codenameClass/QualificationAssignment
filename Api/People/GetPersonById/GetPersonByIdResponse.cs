using Api.People.GetAllPeople;

namespace Api.People.GetPersonById
{
    public record GetPersonByIdResponse
    (
        Guid id,
        string Firstname,
        string Lastname,
        List<string> SocialSkills,
        List<GetPersonByIdSocialAccountResponse> SocialAccounts
    );
}
