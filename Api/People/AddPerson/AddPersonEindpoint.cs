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
                // Validate the request
                var validator = new AddPersonRequestValidator();
                var validationResult = validator.Validate(request);
                if (!validationResult.IsValid)
                {
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    response.ContentType = "application/json";
                    await response.WriteAsync(JsonSerializer.Serialize(validationResult.Errors));
                    return;
                }

                DataContext dataContext = new DataContext("data.json");
                IPersonRepository personRepo = new PersonFileRepository(dataContext);

                Person newPerson = Person.CreateNew
                (
                    Guid.NewGuid(),
                    request.FirstName,
                    request.LastName,
                    request.SocialSkills,
                    request.SocialAccounts.Select(socialAccountRequest =>
                    {
                        return SocialAccount.CreateNew
                        (
                            socialAccountRequest.Type,
                            socialAccountRequest.Address
                        );
                    }).ToList()
                );

                // Save the new person to the database
                personRepo.AddPerson(newPerson);
                await dataContext.SaveChangesAsync();

                AddPersonResponse newPersonResponse = new AddPersonResponse(
                    newPerson.Id,
                    newPerson.FirstName,
                    newPerson.LastName,
                    newPerson.SocialSkills,
                    newPerson.SocialAccounts.Select(socialAccount => {
                        return new AddPersonSocialAccountResponse
                        (
                            socialAccount.Type,
                            socialAccount.Address
                        );
                    }).ToList()
                );

                response.Headers.Add("Location", $"/people/{newPerson.Id}");
                response.StatusCode = StatusCodes.Status201Created;
                response.ContentType = "application/json";
                await JsonSerializer.SerializeAsync(response.Body, newPersonResponse);

            })
            .WithName("AddPerson");

            return app;
        }
    }
}
