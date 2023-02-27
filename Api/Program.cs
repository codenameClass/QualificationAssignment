using Api.People.AddPerson;
using Api.People.DeletePerson;
using Api.People.GetAllPeople;
using Api.People.GetPersonById.Api.People.GetPersonById;
using Api.People.ResultPerson;
using Api.People.UpdatePerson;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(options => options
    .WithOrigins("http://localhost:3000")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


///ENDPOINTS

//GET::/people
app.MapGetAllPeople();

//POST::/people
app.MapAddPerson();

//GET::/people/{id}
app.MapGetPersonById();

//PUT::/people/{id}
app.MapUpdatePerson();

//DELETE::/people/{id}
app.MapDeletePerson();

//GET::/people/{id}/result
app.MapResultPersonById();


app.Run();