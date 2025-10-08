using LevelUp.Application.DurativeRewards.UseCases.CreateDurativeReward;
using LevelUp.Domain.DurativeRewards;

namespace LevelUp.Application.UnitTests.DurativeRewards.UseCases;

public class CreateDurativeRewardUseCaseUnitTests
{
    [Fact(DisplayName = "When a durative reward is created, Then it is done successfully")]
    public async Task When_An_Reward_Is_Created_Then_It_Is_Done_Successfully_Async()
    {
        var mockRewardRepository = Substitute.For<IDurativeRewardRepository>();

        DurativeReward? createdReward = null;

        mockRewardRepository
            .When(rr => rr.Add(Arg.Any<DurativeReward>()))
            .Do(ci => createdReward = ci.Arg<DurativeReward>());

        var useCase = new CreateDurativeRewardUseCase(mockRewardRepository);

        var request = Builder<CreateDurativeRewardRequest>.CreateNew().Build();


        await useCase.HandleAsync(request);


        createdReward.Should().NotBeNull();
        createdReward.Id.Should().NotBe(Guid.Empty);
        createdReward.Name.Should().Be(request.Name);
        createdReward.Duration.Should().Be(request.Duration);
        createdReward.Category.Should().Be(request.Category);
        createdReward.ExpireDate.Should().Be(request.ExpireDate);
    }
}