namespace Api.People.GetPersonById
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
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

                    return Results.Ok(person);
                })
                .WithName("GetPersonById");

                return app;
            }
        }
    }

}
