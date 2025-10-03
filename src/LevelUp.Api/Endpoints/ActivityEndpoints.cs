using LevelUp.Api.Endpoints.DTOs;
using LevelUp.Application.Activities.UseCases.CreateDurativeActivity;
using LevelUp.Application.Activities.UseCases.GetActivities;
using LevelUp.Application.Common.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace LevelUp.Api.Endpoints;

public static class ActivityEndpoints
{
    public static void Map(IEndpointRouteBuilder app, string version)
    {
        app.MapPost($"api/{version}/activities/duratives", async (
            [FromBody] CreateDurativeActivityDto dto,
            [FromServices] IWriteUseCase<CreateDurativeActivityRequest, NothingResponse> useCase
        ) =>
        {
            var request = new CreateDurativeActivityRequest
            {
                Name = dto.Name,
                Date = dto.Date,
                Duration = TimeSpan.Parse(dto.Duration),
                Category = dto.Category,
            };

            await useCase.HandleAsync(request);
            return Results.Ok();
        });

        app.MapGet($"api/{version}/activities/duratives", async (
            [FromServices] IReadUseCase<GetDurativeActivitiesRequest, DurativeActivityResponse[]> useCase
        ) =>
        {
            var response = await useCase.HandleAsync(new GetDurativeActivitiesRequest());
            return Results.Ok(response);
        });
    }
}