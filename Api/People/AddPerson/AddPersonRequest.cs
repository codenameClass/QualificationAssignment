namespace Api.People.AddPerson
{
    public record AddPersonRequest
    (
        string Firstname,
        string Lastname,
        List<string> SocialSkills,
        Dictionary<string, string> SocialAccounts
    );
}
