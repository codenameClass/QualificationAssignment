using Core.Model;
using Core.Repositories;
using DataAccessFile.Data;
using DataAccessFile.Repositories;

namespace Api.People.GetAllPeople
{
    public static class GetAllPeopleEndpoint
    {
        public static IEndpointRouteBuilder MapGetAllPeople(this IEndpointRouteBuilder app)
        {
            app.MapGet("/people", async () =>
            {
                DataContext dataContext = new DataContext("data.json");
                IPersonRepository personRepo = new PersonFileRepository(dataContext);

                return await personRepo.GetAllPeopleAsync();
            })
            .WithName("GetAllPeople");

            return app;
        }
    }
}
