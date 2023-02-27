using Api.People.GetPersonById;
using Core.Model;
using Core.Repositories;
using DataAccessFile.Data;
using DataAccessFile.Repositories;
using System.Text.Json;

namespace Api.People.ResultPerson
{
    public static class ResultPersonByIdEndpoint
    {
        public static IEndpointRouteBuilder MapResultPersonById(this IEndpointRouteBuilder app)
        {
            app.MapGet("/people/{id}/result", async (Guid id) =>
            {
                DataContext dataContext = new DataContext("data.json");
                IPersonRepository personRepo = new PersonFileRepository(dataContext);

                Person person = await personRepo.GetPersonAsync(id);

                if (person == null)
                {
                    return Results.NotFound();
                }

                var fullName = $"{person.Firstname} {person.Lastname}";


                List<ResultPersonSocialAccountResponse> resultSocialAccountResponse = person.SocialAccounts.Select(socialAccount =>
                {
                    return new ResultPersonSocialAccountResponse(socialAccount.Type, socialAccount.Address);

                }).ToList();

                ResultPersonResponse resultPersonResponse = new ResultPersonResponse
                (
                    person.Id,
                    person.Firstname,
                    person.Lastname,
                    person.SocialSkills,
                    resultSocialAccountResponse
                );

                ResultProcessedPersonByIdResponse resultPersonByIdResponse = new ResultProcessedPersonByIdResponse
                (
                    person.Id,
                    NumberOfVowelsInString(fullName),
                    NumberOfConstenantsInString(fullName),
                    fullName,
                    ReverseString(fullName),
                    resultPersonResponse
                );

                return Results.Ok(resultPersonByIdResponse);
            })
            .WithName("ResultPersonById");

            return app;
        }

        public static int NumberOfVowelsInString(string entry) => entry.Count(c => "aeiou".Contains(char.ToLower(c)));
        public static int NumberOfConstenantsInString(string entry) => entry.Count(c => "bcdfghjklmnpqsrtvwxyz".Contains(char.ToLower(c)));
        public static string ReverseString(string entry)
        {
            char[] charArray = entry.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
