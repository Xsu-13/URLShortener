using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pet_Project.Application.Services;
using Pet_Project.Logic.Interfaces;
using Pet_Project.Logic.Models;
using Pet_Project.Persistence.Entities;
using Pet_Project.WebApi.Contracts.URLs;
using Pet_Project.WebApi.Helper;
using System;
using System.Text;

namespace Pet_Project.WebApi.Endpoints
{
    public static class URLEndpoints
    {
        public static IEndpointRouteBuilder MapURLEndpoints(this IEndpointRouteBuilder builder)
        {
            var endpoints = builder;
            endpoints.MapPost(String.Empty, CreateURL);
            endpoints.MapGet("{id:Guid}", GetURLByID);
            endpoints.MapGet("{shortUrl}", GetURLByShortURL);

            return builder;
        }

        private static async Task<IResult> CreateURL(
            [FromBody] CreateURLRequest request,
            UrlService service,
            HttpContext httpContext)
        {
            var newId = Guid.NewGuid();

            var shortURL = await Converter.ConvertToBase62(newId);

            var resultShortURL = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/{shortURL}.omg";

            var url = GeneratingURL.Create(newId, request.LongURL, resultShortURL);

            var id = await service.CreateURL(url);

            return Results.Ok(url);
        }

        private static async Task<IResult> GetURLByID(
            [FromRoute] Guid id,
            UrlService service)
        {
            var url = await service.GetURLById(id);

            var response = new GetURLResponse(url.LongUrl, url.ShortUrl);

            return Results.Ok(response);
        }

        private static async Task<IResult> GetURLByShortURL(
            [FromRoute] string shortURL,
            UrlService service,
            HttpContext httpContext)
        {
            var searchShortURL = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/{shortURL}";
            var url = await service.GetURLByShortURL(searchShortURL);

            if(url == null)
            {
                return Results.NotFound();
            }

            var response = new GetURLResponse(url.LongUrl, url.ShortUrl);

            return Results.Redirect(response.LongURL);
        }
    }
}
