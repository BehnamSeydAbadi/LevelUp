using LevelUp.Application.ActionRewards.UseCases.CreateActionReward;
using LevelUp.Domain.ActionRewards;

namespace LevelUp.Application.UnitTests.ActionRewards.UseCases;

public class CreateActionRewardUseCaseTests
{
    [Fact(DisplayName = "When an action reward is created, Then it is done successfully")]
    public async Task When_An_Action_Reward_Is_Created_Then_It_Is_Done_Successfully_Async()
    {
        var mockRewardRepository = Substitute.For<IActionRewardRepository>();

        ActionReward? createdReward = null;

        mockRewardRepository
            .When(ar => ar.Add(Arg.Any<ActionReward>()))
            .Do(ci => createdReward = ci.Arg<ActionReward>());

        var useCase = new CreateActionRewardUseCase(mockRewardRepository);

        var request = Builder<CreateActionRewardRequest>.CreateNew().Build();


        await useCase.HandleAsync(request);


        createdReward.Should().NotBeNull();
        createdReward.Id.Should().NotBe(Guid.Empty);
        createdReward.Name.Should().Be(request.Name);
        createdReward.Date.Should().Be(request.Date);
        createdReward.Category.Should().Be(request.Category);
    }
}