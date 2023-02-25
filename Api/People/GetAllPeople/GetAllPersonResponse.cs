namespace Api.People.GetAllPeople
{
    public record GetAllPersonResponse
    (
        Guid id,
        string Firstname,
        string Lastname,
        List<string> SocialSkills,
        Dictionary<string, string> SocialAccounts
    );
}
