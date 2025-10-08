using LevelUp.Api.Endpoints.Activities.DTOs;
using LevelUp.Application.ActionActivities.UseCases.CreateActionActivity;
using LevelUp.Application.ActionActivities.UseCases.DeleteActionActivity;
using LevelUp.Application.ActionActivities.UseCases.GetActionActivities;
using LevelUp.Application.ActionActivities.UseCases.UpdateActionActivity;
using LevelUp.Application.Common.UseCases;
using LevelUp.Application.DurativeActivities.UseCases.CreateDurativeActivity;
using LevelUp.Application.DurativeActivities.UseCases.DeleteDurativeActivity;
using LevelUp.Application.DurativeActivities.UseCases.GetDurativeActivities;
using LevelUp.Application.DurativeActivities.UseCases.UpdateDurativeActivity;
using Microsoft.AspNetCore.Mvc;

namespace LevelUp.Api.Endpoints.Activities;

public static class ActivityEndpoints
{
    public static void Map(IEndpointRouteBuilder endpoints, string version)
    {
        endpoints.MapPost($"api/{version}/activities/duratives", async (
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

        endpoints.MapGet($"api/{version}/activities/duratives", async (
            [FromServices] IReadUseCase<GetDurativeActivitiesRequest, DurativeActivityResponse[]> useCase
        ) =>
        {
            var response = await useCase.HandleAsync(new GetDurativeActivitiesRequest());
            return Results.Ok(response);
        });

        endpoints.MapPut($"api/{version}/activities/duratives/{{id}}", async (
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

        endpoints.MapDelete($"api/{version}/activities/duratives/{{id}}", async (
            [FromRoute] Guid id,
            [FromServices] IWriteUseCase<DeleteDurativeActivityRequest, NothingResponse> useCase
        ) =>
        {
            await useCase.HandleAsync(new DeleteDurativeActivityRequest { Id = id });
            return Results.Ok();
        });
        
        
        
        endpoints.MapPost($"api/{version}/activities/actions", async (
            [FromBody] CreateActionActivityDto dto,
            [FromServices] IWriteUseCase<CreateActionActivityRequest, Guid> useCase
        ) =>
        {
            var request = new CreateActionActivityRequest
            {
                Name = dto.Name,
                Date = dto.Date,
                Category = dto.Category,
            };

            var id = await useCase.HandleAsync(request);
            return Results.Ok(id);
        });

        endpoints.MapGet($"api/{version}/activities/actions", async (
            [FromServices] IReadUseCase<GetActionActivitiesRequest, ActionActivityResponse[]> useCase
        ) =>
        {
            var response = await useCase.HandleAsync(new GetActionActivitiesRequest());
            return Results.Ok(response);
        });

        endpoints.MapPut($"api/{version}/activities/actions/{{id}}", async (
            [FromRoute] Guid id,
            [FromBody] UpdateActionActivityDto dto,
            [FromServices] IWriteUseCase<UpdateActionActivityRequest, NothingResponse> useCase
        ) =>
        {
            var request = new UpdateActionActivityRequest
            {
                Id = id,
                Name = dto.Name,
                Date = dto.Date,
                Category = dto.Category,
            };

            await useCase.HandleAsync(request);
            return Results.Ok();
        });

        endpoints.MapDelete($"api/{version}/activities/actions/{{id}}", async (
            [FromRoute] Guid id,
            [FromServices] IWriteUseCase<DeleteActionActivityRequest, NothingResponse> useCase
        ) =>
        {
            await useCase.HandleAsync(new DeleteActionActivityRequest { Id = id });
            return Results.Ok();
        });
    }
}