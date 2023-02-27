using Core.Model;
using Core.Repositories;
using DataAccessFile.Data;
using DataAccessFile.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.ComponentModel;
using System.Text.Json;

namespace Api.People.AddPerson
{
    public static class AddPersonEindpoint
    {
        public static IEndpointRouteBuilder MapAddPerson(this IEndpointRouteBuilder app)
        {
            app.MapPost("/people", async (AddPersonRequest request, HttpResponse response) =>
            {
                DataContext dataContext = new DataContext("data.json");
                IPersonRepository personRepo = new PersonFileRepository(dataContext);

                Person newPerson = new Person()
                {
                    Id = Guid.NewGuid(),
                    Firstname = request.Firstname,
                    Lastname = request.Lastname,
                    SocialSkills = request.SocialSkills,
                    SocialAccounts = request.SocialAccounts.Select(socialAccountRequest =>
                    {
                        return new SocialAccount()
                        { 
                            Type = socialAccountRequest.Type,
                            Address = socialAccountRequest.Address
                        };
                    }).ToList()
                };

                // Save the new person to the database
                personRepo.AddPerson(newPerson);
                await dataContext.SaveChangesAsync();

                response.Headers.Add("Location", $"/people/{newPerson.Id}");
                response.StatusCode = StatusCodes.Status201Created;

                AddPersonResponse newPersonResponse = new AddPersonResponse(
                    newPerson.Id,
                    newPerson.Firstname,
                    newPerson.Lastname,
                    newPerson.SocialSkills,
                    newPerson.SocialAccounts.Select(socialAccount => {
                        return new AddPersonSocialAccountResponse
                        (
                            socialAccount.Type,
                            socialAccount.Address
                        );
                    }).ToList()
                );

                return newPersonResponse;
            })
            .WithName("AddPerson");

            return app;
        }
    }
}
