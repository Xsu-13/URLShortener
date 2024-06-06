using Microsoft.EntityFrameworkCore;
using Pet_Project.Logic.Interfaces;
using Pet_Project.Persistence;
using Pet_Project.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<URLGeneratingDBContext>(options => { options.UseNpgsql(configuration.GetConnectionString(nameof(URLGeneratingDBContext))); });

services.AddScoped<IURLService, URLRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");

services.AddAutoMapper(typeof(DatabaseMapping));

app.Run();
