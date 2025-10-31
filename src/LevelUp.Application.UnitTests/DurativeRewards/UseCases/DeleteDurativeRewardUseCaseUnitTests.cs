using LevelUp.Application.DurativeRewards.Exceptions;
using LevelUp.Application.DurativeRewards.UseCases.DeleteDurativeReward;
using LevelUp.Domain.ManagementContext.DurativeRewards;

namespace LevelUp.Application.UnitTests.DurativeRewards.UseCases;

public class DeleteDurativeRewardUseCaseUnitTests
{
    [Fact(DisplayName = "There is a durative reward, When it gets deleted, Then it is done successfully")]
    public async Task There_Is_A_Durative_Reward_When_It_Gets_Deleted_Then_It_Is_Done_Successfully_Async()
    {
        var entity = Builder<DurativeReward>.CreateNew().Build();

        var durativeRewardRepository = Substitute.For<IDurativeRewardRepository>();

        durativeRewardRepository.GetAsync(Arg.Any<Guid>()).Returns(entity);

        DurativeReward? deletedEntity = null;

        durativeRewardRepository
            .When(rr => rr.Delete(Arg.Any<DurativeReward>()))
            .Do(ci => deletedEntity = ci.Arg<DurativeReward>());

        var useCase = new DeleteDurativeRewardUseCase(durativeRewardRepository);

        var request = Builder<DeleteDurativeRewardRequest>.CreateNew()
            .With(r => r.Id = entity.Id)
            .Build();


        await useCase.HandleAsync(request);


        deletedEntity.Should().NotBeNull();
        deletedEntity.Id.Should().Be(entity.Id);
    }

    [Fact(DisplayName =
        "There is no durative activity, When it gets deleted,  Then DurativeRewardNotFoundException is thrown")]
    public async Task
        There_Is_No_Durative_Reward_When_It_Gets_Deleted_Then_DurativeRewardNotFoundException_Is_Thrown_Async()
    {
        var useCase = new DeleteDurativeRewardUseCase(Substitute.For<IDurativeRewardRepository>());

        var request = Builder<DeleteDurativeRewardRequest>.CreateNew().Build();


        var action = () => useCase.HandleAsync(request);


        await action.Should().ThrowExactlyAsync<DurativeRewardNotFoundException>();
    }
}