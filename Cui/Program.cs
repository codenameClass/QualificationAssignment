using Core.Model;
using Core.Repositories;
using DataAccessFile.Data;
using DataAccessFile.Repositories;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Text.Json;


public class Startup
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            new Startup().RunApp();
        }

    }

    public async void RunApp()
    {
        Debug();
        //MyOutput();
    }

    public void DebugPrintAllPeople(IPersonRepository personRepo, string inputText)
    {
        var people = personRepo.GetAllPeopleAsync().Result;

        Console.WriteLine($"\n-- {inputText} start --");
        people
            .ForEach(person => {
                Console.WriteLine($"{person.Id} {person.Firstname} {person.Lastname}");
            });
        Console.WriteLine($"--  {inputText} end --\n"); ;
    }

    public void DebugClearFile(DataContext dataContext)
    {
        //CLEAR
        dataContext.Clear();
        dataContext.SaveChangesAsync().Wait();
    }

    public void DebugAdd(IPersonRepository personRepo, DataContext dataContext)
    {
        //ADD
        personRepo.AddPerson(new Person()
        {
            Id = Guid.NewGuid(),
            Firstname = "John",
            Lastname = "Boris",
            SocialSkills = new List<string> { "social", "fun", "coach" },
            SocialAccounts = new Dictionary<string, string>
            {
                {  "Twitter", "@JohnDoe" },
                {  "Linkedin", "Linkedin.com/johndoe" }
            }
        });

        dataContext.SaveChangesAsync().Wait();
    }

    public void DebugUpdate(IPersonRepository personRepo, DataContext dataContext)
    {
        //UPDATE
        personRepo.GetAllPeopleAsync().Result.First().Firstname = "Update";
        dataContext.SaveChangesAsync().Wait();
    }
    public void Debug()
    {
        //SETUP
        DataContext dataContext = new DataContext("data.json");
        IPersonRepository personRepo = new PersonFileRepository(dataContext);

        DebugPrintAllPeople(personRepo, "LOAD FILE");

        /*DebugClearFile(dataContext);
        DebugPrintAllPeople(personRepo, "CLEARED FILE");*/

        DebugAdd(personRepo, dataContext);
        DebugPrintAllPeople(personRepo, "ADDED FILE");

        DebugUpdate(personRepo, dataContext);
        DebugPrintAllPeople(personRepo, "UPDATED FILE");


        Console.WriteLine($"-------------------------");
    }

    public void MyOutput()
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
    public int NumberOfVowelsInString(string entry) => entry.Count(c => "aeiou".Contains(char.ToLower(c)));
    public int NumberOfConstenantsInString(string entry) => entry.Count(c => "bcdfghjklmnpqsrtvwxyz".Contains(char.ToLower(c)));
    public string ReverseString(string entry)
    {
        char[] charArray = entry.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    public string FormatDtoToJson(object inputDto) => JsonSerializer.Serialize(inputDto, new JsonSerializerOptions { WriteIndented = true });
}



/* 
         * 
         * people
            .ForEach(person => {
                personRepo.DeletePerson(person);
            });

         * */

/*
Parallel.ForEachAsync(people, async (person, token) =>
{
    await personRepo.DeletePersonAsync(person.Id);
});
*/

/*
personRepo.UpdatePerson(new Person()
{
    Id = personRepo.GetAllPeopleAsync().Result.First().Id,
    Firstname = "John",
    Lastname = "Boris",
    SocialSkills = new List<string> { "social", "fun", "coach" },
    SocialAccounts = new Dictionary<string, string>
    {
        {  "Twitter", "@JohnDoe" },
        {  "Linkedin", "Linkedin.com/johndoe" }
    }
});
*/