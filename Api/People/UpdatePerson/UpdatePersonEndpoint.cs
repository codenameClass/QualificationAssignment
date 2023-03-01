using Api.People.AddPerson;
using Core.Model;
using Core.Repositories;
using DataAccessFile.Data;
using DataAccessFile.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.People.UpdatePerson
{
    public static class UpdatePersonEndpoint
    {
        public static IEndpointRouteBuilder MapUpdatePerson(this IEndpointRouteBuilder app)
        {
            app.MapPut("/people/{id}", async (Guid id, UpdatePersonRequest request, HttpResponse response) =>
            {
                // Validate the request
                var validator = new UpdatePersonRequestValidator();
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

                // Check if the person exists in the repository
                Person existingPerson = await personRepo.GetPersonAsync(id);
                if (existingPerson == null)
                {
                    response.StatusCode = StatusCodes.Status404NotFound;
                    return;
                }

                // Update the person's properties with the values from the request
                existingPerson.FirstName = request.FirstName;
                existingPerson.LastName = request.LastName;
                existingPerson.SocialSkills = request.SocialSkills;
                existingPerson.SocialAccounts = request.SocialAccounts.Select(socialAccountRequest => {
                    return SocialAccount.CreateNew
                    ( 
                        socialAccountRequest.Type,
                        socialAccountRequest.Address
                    );
                }).ToList();

                // Save the changes to the repository
                await dataContext.SaveChangesAsync();

                response.StatusCode = StatusCodes.Status204NoContent;
            })
            .WithName("UpdatePerson");

            return app;
        }
    }
}
