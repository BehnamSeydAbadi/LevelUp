using LevelUp.Application.Common;
using LevelUp.Application.Common.UseCases;

namespace LevelUp.Application.Activities.UseCases.CreateActivity;

public record CreateActivityUseCaseDto : IUseCaseDto
{
    public string Name { get; init; }
    public DateTimeOffset Date { get; init; }
    public TimeSpan Duration { get; init; }
    public string Category { get; init; }
}