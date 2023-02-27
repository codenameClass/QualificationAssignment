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

                var people = await personRepo.GetAllPeopleAsync();

                return people.Select(p => 
                    new GetAllPersonResponse
                    (
                        p.Id,
                        p.Firstname,
                        p.Lastname,
                        p.SocialSkills,
                        p.SocialAccounts.Select(socialAccount =>
                        {
                            return new GetAllPersonSocialAccountResponse(socialAccount.Type, socialAccount.Address);
                        }).ToList()
                    )
                );
            })
            .WithName("GetAllPeople");

            return app;
        }
    }
}
