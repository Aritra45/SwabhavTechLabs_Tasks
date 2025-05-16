using ContactAppUsingWebApi.Repository;
using DemoApi;
using DemoApi.DataAccess;
using DemoApi.Handlers;
using DemoApi.Interfaces.IRepositoryes;
using DemoApi.Interfaces.IServices;
using DemoApi.Models;
using DemoApi.Queries;
using DemoApi.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using static DemoApi.Queries.GenericQueries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IDataAccess, DemoDataAccess>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IGenericRepository<PersonModel>, GenericRepository<PersonModel>>();
builder.Services.AddScoped<IRequestHandler<GenericQueries.AddPersonQuery<PersonModel>, PersonModel>, GenericHandler<IPersonService, PersonModel>>();
builder.Services.AddScoped<IRequestHandler<GenericQueries.DeletePersonQuery<PersonModel>, PersonModel>, GenericHandler<IPersonService, PersonModel>>();
builder.Services.AddScoped<IRequestHandler<GenericQueries.GetByIdQuery<PersonModel>, PersonModel>, GenericHandler<IPersonService, PersonModel>>();
builder.Services.AddScoped<IRequestHandler<GenericQueries.GetPersonListQuery<PersonModel>, List<PersonModel>>, GenericHandler<IPersonService, PersonModel>>();
builder.Services.AddScoped<IRequestHandler<GenericQueries.UpdatePersonQuery<PersonModel>, PersonModel>, GenericHandler<IPersonService, PersonModel>>();



builder.Services.AddMediatR(typeof(DemoLibraryMediatREntrypoint).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GSMKTG API",
        Version = "v1"
    });
});
builder.Services.AddDbContext<DemoDataAccess>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
