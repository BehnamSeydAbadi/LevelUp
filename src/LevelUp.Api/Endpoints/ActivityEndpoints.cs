using LevelUp.Api.Endpoints.DTOs;
using LevelUp.Application.Activities.UseCases.CreateActivity;
using LevelUp.Application.Activities.UseCases.GetActivities;
using LevelUp.Application.Common.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace LevelUp.Api.Endpoints;

public static class ActivityEndpoints
{
    public static void Map(IEndpointRouteBuilder app, string version)
    {
        app.MapPost($"api/{version}/activities", async (
            [FromBody] CreateActivityDto dto,
            [FromServices] IUseCase<CreateActivityRequest, NothingResponse> useCase
        ) =>
        {
            var request = new CreateActivityRequest
            {
                Name = dto.Name,
                Date = dto.Date,
                Duration = TimeSpan.Parse(dto.Duration),
                Category = dto.Category,
            };

            await useCase.HandleAsync(request);
            return Results.Ok();
        });

        app.MapGet($"api/{version}/activities", async (
            [FromServices] IUseCase<GetActivitiesRequest, ActivityResponse[]> useCase
        ) =>
        {
            var response = await useCase.HandleAsync(new GetActivitiesRequest());
            return Results.Ok(response);
        });
    }
}