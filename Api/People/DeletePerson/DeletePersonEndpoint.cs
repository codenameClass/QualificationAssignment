using Core.Model;
using Core.Repositories;
using DataAccessFile.Data;
using DataAccessFile.Repositories;

namespace Api.People.DeletePerson
{
    public static class DeletePersonEndpoint
    {
        public static IEndpointRouteBuilder MapDeletePerson(this IEndpointRouteBuilder app)
        {
            app.MapDelete("/people/{id}", async (HttpContext context, Guid id) =>
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

                // Remove the person from the repository
                personRepo.DeletePerson(existingPerson);
                await dataContext.SaveChangesAsync();

                context.Response.StatusCode = StatusCodes.Status204NoContent;
            })
            .WithName("DeletePerson");

            return app;
        }
    }
}
