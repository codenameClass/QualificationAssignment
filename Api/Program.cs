using Api.People.AddPerson;
using Api.People.DeletePerson;
using Api.People.GetAllPeople;
using Api.People.GetPersonById.Api.People.GetPersonById;
using Api.People.ResultPerson;
using Api.People.UpdatePerson;
using Core.Model;
using Core.Repositories;
using DataAccessFile.Data;
using DataAccessFile.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
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