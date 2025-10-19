using LevelUp.Application.ActionRewards.Exceptions;
using LevelUp.Application.ActionRewards.UseCases.DeleteActionReward;
using LevelUp.Domain.ActionRewards;

namespace LevelUp.Application.UnitTests.ActionRewards.UseCases;

public class DeleteActionRewardUseCaseTests
{
    [Fact(DisplayName = "There is an action reward, When it gets deleted, Then it is done successfully")]
    public async Task There_Is_An_Action_Reward_When_It_Gets_Deleted_Then_It_Is_Done_Successfully_Async()
    {
        var entity = Builder<ActionReward>.CreateNew().Build();

        var mockRewardRepository = Substitute.For<IActionRewardRepository>();

        mockRewardRepository.GetAsync(Arg.Any<Guid>()).Returns(entity);

        ActionReward? deletedEntity = null;

        mockRewardRepository
            .When(ar => ar.Delete(Arg.Any<ActionReward>()))
            .Do(ci => deletedEntity = ci.Arg<ActionReward>());

        var useCase = new DeleteActionRewardUseCase(mockRewardRepository);

        var request = Builder<DeleteActionRewardRequest>.CreateNew()
            .With(r => r.Id = entity.Id)
            .Build();


        await useCase.HandleAsync(request);


        deletedEntity.Should().NotBeNull();
        deletedEntity.Id.Should().Be(entity.Id);
    }

    [Fact(DisplayName = "There is no action reward, When it gets deleted,  Then ActionRewardNotFoundException is thrown")]
    public async Task
        There_Is_No_Action_Reward_When_It_Gets_Deleted_Then_ActionRewardNotFoundException_Is_Thrown_Async()
    {
        var useCase = new DeleteActionRewardUseCase(Substitute.For<IActionRewardRepository>());

        var request = Builder<DeleteActionRewardRequest>.CreateNew().Build();


        var action = () => useCase.HandleAsync(request);


        await action.Should().ThrowExactlyAsync<ActionRewardNotFoundException>();
    }
}