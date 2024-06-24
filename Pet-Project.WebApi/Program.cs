using Microsoft.EntityFrameworkCore;
using Pet_Project.Logic.Interfaces;
using Pet_Project.Persistence;
using Pet_Project.Persistence.Repositories;
using Pet_Project.WebApi.Endpoints;
using Pet_Project.Application.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<URLGeneratingDBContext>(options => { options.UseNpgsql(configuration.GetConnectionString(nameof(URLGeneratingDBContext))); });

services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = configuration.GetConnectionString("URLGeneratingRedis");
});

services.AddScoped<IURLService, URLRepository>();

services.AddScoped<UrlService>();

services.AddAutoMapper(typeof(DatabaseMapping));

services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.MapGet("/", () => "Hello World!");
app.MapURLEndpoints();

app.Use((context, next) =>
{ 
    context.Response.Redirect("/swagger");

    return next();
});

app.Run();
