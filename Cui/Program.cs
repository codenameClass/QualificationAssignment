using Core.Model;
using Core.Repositories;
using Cui;
using DataAccessFile.Data;
using DataAccessFile.Repositories;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Net.Sockets;
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
        //Debug();
        MyOutput();
        //Reset();
    }

    public void Reset()
    {
        DataContext dataContext = new DataContext("data.json");
        DebugClearFile(dataContext);
    }

    public void DebugPrintAllPeople(IPersonRepository personRepo, string inputText)
    {
        var people = personRepo.GetAllPeopleAsync().Result;

        Console.WriteLine($"\n-- {inputText} start --");
        people
            .ForEach(person => {
                Console.WriteLine($"{person.Id} {person.FirstName} {person.LastName}");
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
        personRepo.AddPerson(Person.CreateNew
        (
            Guid.NewGuid(),
            "John",
            "Boris",
            new List<string> { "social", "fun", "coach" },
            new List<SocialAccount>
            {
                SocialAccount.CreateNew("Twitter", "@JohnDoe"),
                SocialAccount.CreateNew("Linkedin", "Linkedin.com/johndoe")
            }
        ));

        dataContext.SaveChangesAsync().Wait();
    }

    public void DebugUpdate(IPersonRepository personRepo, DataContext dataContext)
    {
        //UPDATE
        personRepo.GetAllPeopleAsync().Result.First().FirstName = "Update";
        dataContext.SaveChangesAsync().Wait();
    }
    public void Debug()
    {
        //SETUP
        DataContext dataContext = new DataContext("data.json");
        IPersonRepository personRepo = new PersonFileRepository(dataContext);

        //DebugPrintAllPeople(personRepo, "LOAD FILE");

        DebugClearFile(dataContext);
        DebugPrintAllPeople(personRepo, "CLEARED FILE");

        //DebugAdd(personRepo, dataContext);
        //DebugPrintAllPeople(personRepo, "ADDED FILE");

        //DebugUpdate(personRepo, dataContext);
        //DebugPrintAllPeople(personRepo, "UPDATED FILE");


        Console.WriteLine($"-------------------------");
    }

    public void MyOutput()
    {
        PersonInputDto personInputDto = new PersonInputDto
        (
            "John",
            "Doe",
            new List<string> { "social", "fun", "coach" },
            new List<SocialAccountInputDto>
            {
                new ("Twitter", "@JohnDoe"),
                new ("Linkedin", "Linkedin.com/johndoe")
            }
        );

        var fullName = $"{personInputDto.FirstName} {personInputDto.LastName}";

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