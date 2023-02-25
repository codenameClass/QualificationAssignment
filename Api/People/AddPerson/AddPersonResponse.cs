namespace Api.People.AddPerson
{
    public record AddPersonResponse
    (
        Guid id,
        string Firstname,
        string Lastname,
        List<string> SocialSkills,
        Dictionary<string, string> SocialAccounts
    );
}
