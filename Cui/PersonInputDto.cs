public class PersonInputDto
{
    public string Firstname { get; init; }
    public string Lastname { get; init; }
    public List<string> SocialSkills { get; init; }
    public Dictionary<string, string> SocialAccounts { get; init; }
}
