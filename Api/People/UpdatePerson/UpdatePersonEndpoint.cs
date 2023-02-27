using Api.People.AddPerson;
using Core.Model;
using Core.Repositories;
using DataAccessFile.Data;
using DataAccessFile.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.People.UpdatePerson
{
    public static class UpdatePersonEndpoint
    {
        public static IEndpointRouteBuilder MapUpdatePerson(this IEndpointRouteBuilder app)
        {
            app.MapPut("/people/{id}", async (HttpContext context, Guid id, [FromBody] UpdatePersonRequest request) =>
            {
                DataContext dataContext = new DataContext("data.json");
                IPersonRepository personRepo = new PersonFileRepository(dataContext);

                // Check if the person exists in the repository
                Person existingPerson = await personRepo.GetPersonAsync(id);
                if (existingPerson == null)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    return;
                }

                // Update the person's properties with the values from the request
                existingPerson.Firstname = request.Firstname;
                existingPerson.Lastname = request.Lastname;
                existingPerson.SocialSkills = request.SocialSkills;
                existingPerson.SocialAccounts = request.SocialAccounts.Select(socialAccountRequest => {
                    return new SocialAccount()
                    { 
                        Type= socialAccountRequest.Type,
                        Address= socialAccountRequest.Address
                    };
                }).ToList();

                // Save the changes to the repository
                await dataContext.SaveChangesAsync();

                context.Response.StatusCode = StatusCodes.Status204NoContent;
            })
            .WithName("UpdatePerson");

            return app;
        }
    }
}
