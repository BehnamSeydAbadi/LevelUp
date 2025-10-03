using LevelUp.Application.DurativeActivities.UseCases.CreateDurativeActivity;
using LevelUp.Domain.DurativeActivities;

namespace LevelUp.Application.UnitTests.DurativeActivities.UseCases.CreateDurativeActivity;

public class CreateDurativeActivityUseCaseTests
{
    [Fact(DisplayName = "When a durative activity is created, Then it is done successfully")]
    public async Task When_An_Activity_Is_Created_Then_It_Is_Done_Successfully_Async()
    {
        var mockActivityRepository = Substitute.For<IDurativeActivityRepository>();

        DurativeActivity? createdActivity = null;

        mockActivityRepository
            .When(ar => ar.Add(Arg.Any<DurativeActivity>()))
            .Do(ci => createdActivity = ci.Arg<DurativeActivity>());

        var useCase = new CreateDurativeActivityUseCase(mockActivityRepository);

        var request = Builder<CreateDurativeActivityRequest>.CreateNew().Build();


        await useCase.HandleAsync(request);


        createdActivity.Should().NotBeNull();
        createdActivity.Id.Should().NotBe(Guid.Empty);
        createdActivity.Name.Should().Be(request.Name);
        createdActivity.Date.Should().Be(request.Date);
        createdActivity.Duration.Should().Be(request.Duration);
        createdActivity.Category.Should().Be(request.Category);
    }
}