using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        PersonInputDto personInputDto = new PersonInputDto()
        {
            Firstname = "Jens",
            Lastname = "Ingels",
            SocialSkills = new List<string> { "social", "fun", "coach" },
            SocialAccounts = new Dictionary<string, string>
            {
                {  "Twitter", "@JohnDoe" },
                {  "Linkedin", "Linkedin.com/johndoe" }
            }

        };

        var fullName = $"{personInputDto.Firstname} {personInputDto.Lastname}";

        Console.WriteLine($"The number of VOWELS: {NumberOfVowelsInString(fullName)}");
        Console.WriteLine($"The number of CONSTENANTS: {NumberOfConstenantsInString(fullName)}");
        Console.WriteLine($"The firstname + last name entered: {fullName}");
        Console.WriteLine($"The reverse version of the firstname and lastname: {ReverseString(fullName)}");
        Console.WriteLine($"The JSON format of the entire object:\n{FormatDtoToJson(personInputDto)}");
    }


    public static int NumberOfVowelsInString(string entry) => entry.Count(c => "aeiou".Contains(char.ToLower(c)));
    public static int NumberOfConstenantsInString(string entry) => entry.Count(c => "bcdfghjklmnpqsrtvwxyz".Contains(char.ToLower(c)));
    public static string ReverseString(string entry)
    {
        char[] charArray = entry.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    public static string FormatDtoToJson(object inputDto) => JsonSerializer.Serialize(inputDto, new JsonSerializerOptions { WriteIndented = true });

}