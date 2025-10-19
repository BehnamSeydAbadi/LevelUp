using LevelUp.Api.Endpoints.Rewards.DTOs;
using LevelUp.Application.ActionRewards.UseCases.CreateActionReward;
using LevelUp.Application.ActionRewards.UseCases.DeleteActionReward;
using LevelUp.Application.ActionRewards.UseCases.GetActionReward;
using LevelUp.Application.ActionRewards.UseCases.UpdateActionReward;
using LevelUp.Application.Common.UseCases;
using LevelUp.Application.DurativeRewards.Responses;
using LevelUp.Application.DurativeRewards.UseCases.CreateDurativeReward;
using LevelUp.Application.DurativeRewards.UseCases.DeleteDurativeReward;
using LevelUp.Application.DurativeRewards.UseCases.GetDurativeReward;
using LevelUp.Application.DurativeRewards.UseCases.GetDurativeRewards;
using LevelUp.Application.DurativeRewards.UseCases.UpdateDurativeReward;
using Microsoft.AspNetCore.Mvc;

namespace LevelUp.Api.Endpoints.Rewards;

public static class RewardEndpoints
{
    public static void Map(IEndpointRouteBuilder endpoints, string version)
    {
        endpoints.MapPost($"api/{version}/rewards/duratives", async (
            [FromBody] CreateDurativeRewardDto dto,
            [FromServices] IWriteUseCase<CreateDurativeRewardRequest, Guid> useCase
        ) =>
        {
            var request = new CreateDurativeRewardRequest
            {
                Name = dto.Name,
                ExpireDate = dto.ExpireDate,
                Duration = TimeSpan.Parse(dto.Duration),
                Category = dto.Category,
            };

            var id = await useCase.HandleAsync(request);
            return Results.Ok(id);
        });

        endpoints.MapGet($"api/{version}/rewards/duratives", async (
            [FromServices] IReadUseCase<GetDurativeRewardsRequest, DurativeRewardResponse[]> useCase
        ) =>
        {
            var response = await useCase.HandleAsync(new GetDurativeRewardsRequest());
            return Results.Ok(response);
        });

        endpoints.MapGet($"api/{version}/rewards/duratives/{{id}}", async (
            [FromRoute] Guid id,
            [FromServices] IReadUseCase<GetDurativeRewardRequest, DurativeRewardResponse?> useCase
        ) =>
        {
            var response = await useCase.HandleAsync(new GetDurativeRewardRequest { Id = id });
            return response is null ? Results.NoContent() : Results.Ok(response);
        });

        endpoints.MapPut($"api/{version}/rewards/duratives/{{id}}", async (
            [FromRoute] Guid id,
            [FromBody] UpdateDurativeRewardDto dto,
            [FromServices] IWriteUseCase<UpdateDurativeRewardRequest, NothingResponse> useCase
        ) =>
        {
            var request = new UpdateDurativeRewardRequest
            {
                Id = id,
                Name = dto.Name,
                ExpireDate = dto.ExpireDate,
                Duration = TimeSpan.Parse(dto.Duration),
                Category = dto.Category,
            };

            await useCase.HandleAsync(request);
            return Results.Ok();
        });

        endpoints.MapDelete($"api/{version}/rewards/duratives/{{id}}", async (
            [FromRoute] Guid id,
            [FromServices] IWriteUseCase<DeleteDurativeRewardRequest, NothingResponse> useCase
        ) =>
        {
            await useCase.HandleAsync(new DeleteDurativeRewardRequest { Id = id });
            return Results.Ok();
        });


        endpoints.MapPost($"api/{version}/rewards/actions", async (
            [FromBody] CreateActionRewardDto dto,
            [FromServices] IWriteUseCase<CreateActionRewardRequest, Guid> useCase
        ) =>
        {
            var request = new CreateActionRewardRequest
            {
                Name = dto.Name,
                Date = dto.Date,
                Category = dto.Category,
            };

            var id = await useCase.HandleAsync(request);
            return Results.Ok(id);
        });

        endpoints.MapGet($"api/{version}/rewards/actions", async (
            [FromServices] IReadUseCase<GetActionRewardsRequest, ActionRewardResponse[]> useCase
        ) =>
        {
            var response = await useCase.HandleAsync(new GetActionRewardsRequest());
            return Results.Ok(response);
        });

        endpoints.MapPut($"api/{version}/rewards/actions/{{id}}", async (
            [FromRoute] Guid id,
            [FromBody] UpdateActionRewardDto dto,
            [FromServices] IWriteUseCase<UpdateActionRewardRequest, NothingResponse> useCase
        ) =>
        {
            var request = new UpdateActionRewardRequest
            {
                Id = id,
                Name = dto.Name,
                Date = dto.Date,
                Category = dto.Category,
            };

            await useCase.HandleAsync(request);
            return Results.Ok();
        });

        endpoints.MapDelete($"api/{version}/rewards/actions/{{id}}", async (
            [FromRoute] Guid id,
            [FromServices] IWriteUseCase<DeleteActionRewardRequest, NothingResponse> useCase
        ) =>
        {
            await useCase.HandleAsync(new DeleteActionRewardRequest { Id = id });
            return Results.Ok();
        });
    }
}