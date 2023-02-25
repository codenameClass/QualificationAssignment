namespace Api.People.GetPersonById
{
    public record GetPersonByIdResponse
    (
        Guid id,
        string Firstname,
        string Lastname,
        List<string> SocialSkills,
        Dictionary<string, string> SocialAccounts
    );
}
