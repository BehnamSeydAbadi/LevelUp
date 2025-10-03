using LevelUp.Application.Activities.UseCases.CreateActivity;
using LevelUp.Application.Common.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace LevelUp.Api.Endpoints;

public static class ActivityEndpoints
{
    public static void Map(IEndpointRouteBuilder app, string version)
    {
        app.MapPost($"api/{version}/activities", async (
            [FromBody] CreateActivityRequest request,
            [FromServices] IUseCase<CreateActivityRequest, NothingResponse> useCase
        ) =>
        {
            await useCase.HandleAsync(request);
            return Results.Ok();
        });
    }
}