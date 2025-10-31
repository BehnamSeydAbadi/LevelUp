using LevelUp.Application.ActionActivities.UseCases.CreateActionActivity;
using LevelUp.Domain.ManagementContext.ActionActivities;

namespace LevelUp.Application.UnitTests.ActionActivities.UseCases;

public class CreateActionActivityUseCaseTests
{
    [Fact(DisplayName = "When an action activity is created, Then it is done successfully")]
    public async Task When_An_Action_Activity_Is_Created_Then_It_Is_Done_Successfully_Async()
    {
        var mockActivityRepository = Substitute.For<IActionActivityRepository>();

        ActionActivity? createdActivity = null;

        mockActivityRepository
            .When(ar => ar.Add(Arg.Any<ActionActivity>()))
            .Do(ci => createdActivity = ci.Arg<ActionActivity>());

        var useCase = new CreateActionActivityUseCase(mockActivityRepository);

        var request = Builder<CreateActionActivityRequest>.CreateNew().Build();


        await useCase.HandleAsync(request);


        createdActivity.Should().NotBeNull();
        createdActivity.Id.Should().NotBe(Guid.Empty);
        createdActivity.Name.Should().Be(request.Name);
        createdActivity.Date.Should().Be(request.Date);
        createdActivity.Category.Should().Be(request.Category);
        createdActivity.RewardId.Should().Be(request.RewardId);
    }
}