using LevelUp.Application.Activities.UseCases.CreateActivity;
using LevelUp.Domain.Activities;

namespace LevelUp.Application.UnitTests.Activities.UseCases.CreateActivity;

public class CreateActivityUseCaseTests
{
    [Fact(DisplayName = "When an activity is created, Then it is done successfully")]
    public async Task When_An_Activity_Is_Created_Then_It_Is_Done_Successfully_Async()
    {
        var mockActivityRepository = Substitute.For<IActivityRepository>();

        Activity? createdActivity = null;

        mockActivityRepository
            .When(ar => ar.Add(Arg.Any<Activity>()))
            .Do(ci => createdActivity = ci.Arg<Activity>());

        var useCase = new CreateActivityUseCase(mockActivityRepository);

        var request = Builder<CreateActivityRequest>.CreateNew().Build();


        await useCase.HandleAsync(request);


        createdActivity.Should().NotBeNull();
        createdActivity.Id.Should().NotBe(Guid.Empty);
        createdActivity.Name.Should().Be(request.Name);
        createdActivity.Date.Should().Be(request.Date);
        createdActivity.Duration.Should().Be(request.Duration);
        createdActivity.Category.Should().Be(request.Category);
    }
}