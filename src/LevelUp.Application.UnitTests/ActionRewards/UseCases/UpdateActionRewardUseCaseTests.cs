using LevelUp.Application.ActionRewards.Exceptions;
using LevelUp.Application.ActionRewards.UseCases.UpdateActionReward;
using LevelUp.Domain.ActionRewards;

namespace LevelUp.Application.UnitTests.ActionRewards.UseCases;

public class UpdateActionRewardUseCaseTests
{
    [Fact(DisplayName = "There is an action reward, When it gets updated, Then it is done successfully")]
    public async Task There_Is_An_Action_Reward_When_It_Gets_Updated_Then_It_Is_Done_Successfully_Async()
    {
        var entity = Builder<ActionReward>.CreateNew().Build();

        var mockRewardRepository = Substitute.For<IActionRewardRepository>();

        mockRewardRepository.GetAsync(Arg.Any<Guid>()).Returns(entity);

        ActionReward? updatedEntity = null;

        mockRewardRepository
            .When(ar => ar.Update(Arg.Any<ActionReward>()))
            .Do(ci => updatedEntity = ci.Arg<ActionReward>());

        var useCase = new UpdateActionRewardUseCase(mockRewardRepository);

        var request = Builder<UpdateActionRewardRequest>.CreateNew()
            .With(r => r.Id = entity.Id)
            .Build();


        await useCase.HandleAsync(request);


        updatedEntity.Should().NotBeNull();
        updatedEntity.Id.Should().Be(entity.Id);
        updatedEntity.Name.Should().Be(request.Name);
        updatedEntity.Date.Should().Be(request.Date);
        updatedEntity.Category.Should().Be(request.Category);
    }

    [Fact(DisplayName =
        "There is no action reward, When it gets updated, Then ActionRewardNotFoundException is thrown")]
    public async Task
        There_Is_No_Action_Reward_When_It_Gets_Updated_Then_ActionRewardNotFoundException_Is_Thrown_Async()
    {
        var useCase = new UpdateActionRewardUseCase(Substitute.For<IActionRewardRepository>());

        var request = Builder<UpdateActionRewardRequest>.CreateNew().Build();


        var action = () => useCase.HandleAsync(request);


        await action.Should().ThrowExactlyAsync<ActionRewardNotFoundException>();
    }
}