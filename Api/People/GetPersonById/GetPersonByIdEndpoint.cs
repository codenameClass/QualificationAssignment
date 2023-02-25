namespace Api.People.GetPersonById
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Core.Model;
    using Core.Repositories;
    using DataAccessFile.Data;
    using DataAccessFile.Repositories;

    namespace Api.People.GetPersonById
    {
        public static class GetPersonByIdEndpoint
        {
            public static IEndpointRouteBuilder MapGetPersonById(this IEndpointRouteBuilder app)
            {
                app.MapGet("/people/{id}", async (Guid id) =>
                {
                    DataContext dataContext = new DataContext("data.json");
                    IPersonRepository personRepo = new PersonFileRepository(dataContext);

                    Person person = await personRepo.GetPersonAsync(id);

                    if (person == null)
                    {
                        return Results.NotFound();
                    }

                    GetPersonByIdResponse getPersonResponse = new GetPersonByIdResponse
                    (
                        person.Id,
                        person.Firstname,
                        person.Lastname,
                        person.SocialSkills,
                        person.SocialAccounts
                    );

                    return Results.Ok(getPersonResponse);
                })
                .WithName("GetPersonById");

                return app;
            }
        }
    }

}
