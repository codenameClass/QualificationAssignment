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
            app.MapPost("/people", async (HttpContext context, [FromBody] AddPersonRequest request) =>
            {
                DataContext dataContext = new DataContext("data.json");
                IPersonRepository personRepo = new PersonFileRepository(dataContext);

                // Deserialize the request body into a Person object
                var options = new JsonSerializerOptions();
                options.Converters.Add(new GuidConverter());
                Person newPerson = await JsonSerializer.DeserializeAsync<Person>(context.Request.Body, options);
                //newPerson.Id = Guid.NewGuid();

                // Add the new person to the repository
                personRepo.AddPerson(newPerson);
                await dataContext.SaveChangesAsync();

                // Return a 201 Created response with the new person's ID in the Location header
                context.Response.Headers.Add("Location", $"/people/{newPerson.Id}");
                context.Response.StatusCode = StatusCodes.Status201Created;
            })
            .WithName("AddPerson");

            return app;
        }
    }
}
