using LevelUp.Api.Endpoints.DTOs;
using LevelUp.Application.Common.UseCases;
using LevelUp.Application.DurativeActivities.UseCases.CreateDurativeActivity;
using LevelUp.Application.DurativeActivities.UseCases.GetDurativeActivities;
using LevelUp.Application.DurativeActivities.UseCases.UpdateDurativeActivity;
using Microsoft.AspNetCore.Mvc;

namespace LevelUp.Api.Endpoints;

public static class ActivityEndpoints
{
    public static void Map(IEndpointRouteBuilder app, string version)
    {
        app.MapPost($"api/{version}/activities/duratives", async (
            [FromBody] CreateDurativeActivityDto dto,
            [FromServices] IWriteUseCase<CreateDurativeActivityRequest, Guid> useCase
        ) =>
        {
            var request = new CreateDurativeActivityRequest
            {
                Name = dto.Name,
                Date = dto.Date,
                Duration = TimeSpan.Parse(dto.Duration),
                Category = dto.Category,
            };

            var id = await useCase.HandleAsync(request);
            return Results.Ok(id);
        });

        app.MapGet($"api/{version}/activities/duratives", async (
            [FromServices] IReadUseCase<GetDurativeActivitiesRequest, DurativeActivityResponse[]> useCase
        ) =>
        {
            var response = await useCase.HandleAsync(new GetDurativeActivitiesRequest());
            return Results.Ok(response);
        });

        app.MapPut($"api/{version}/activities/duratives/{{id}}", async (
            [FromRoute] Guid id,
            [FromBody] UpdateDurativeActivityDto dto,
            [FromServices] IWriteUseCase<UpdateDurativeActivityRequest, NothingResponse> useCase
        ) =>
        {
            var request = new UpdateDurativeActivityRequest
            {
                Id = id,
                Name = dto.Name,
                Date = dto.Date,
                Duration = TimeSpan.Parse(dto.Duration),
                Category = dto.Category,
            };

            await useCase.HandleAsync(request);
            return Results.Ok();
        });
    }
}