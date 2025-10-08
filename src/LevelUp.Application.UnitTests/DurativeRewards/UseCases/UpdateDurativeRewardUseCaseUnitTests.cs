using LevelUp.Application.DurativeRewards.Exceptions;
using LevelUp.Application.DurativeRewards.UseCases.UpdateDurativeReward;
using LevelUp.Domain.DurativeRewards;

namespace LevelUp.Application.UnitTests.DurativeRewards.UseCases;

public class UpdateDurativeRewardUseCaseUnitTests
{
    [Fact(DisplayName = "There is a durative reward, When it gets updated, Then it is done successfully")]
    public async Task There_Is_A_Durative_Reward_When_It_Gets_Updated_Then_It_Is_Done_Successfully_Async()
    {
        var entity = Builder<DurativeReward>.CreateNew().Build();

        var mockRewardRepository = Substitute.For<IDurativeRewardRepository>();

        mockRewardRepository.GetAsync(Arg.Any<Guid>()).Returns(entity);

        DurativeReward? updatedEntity = null;

        mockRewardRepository
            .When(rr => rr.Update(Arg.Any<DurativeReward>()))
            .Do(ci => updatedEntity = ci.Arg<DurativeReward>());

        var useCase = new UpdateDurativeRewardUseCase(mockRewardRepository);

        var request = Builder<UpdateDurativeRewardRequest>.CreateNew()
            .With(r => r.Id = entity.Id)
            .Build();


        await useCase.HandleAsync(request);


        updatedEntity.Should().NotBeNull();
        updatedEntity.Id.Should().Be(entity.Id);
        updatedEntity.Name.Should().Be(request.Name);
        updatedEntity.Duration.Should().Be(request.Duration);
        updatedEntity.Category.Should().Be(request.Category);
        updatedEntity.ExpireDate.Should().Be(request.ExpireDate);
    }

    [Fact(DisplayName =
        "There is no durative reward, When it gets updated, Then DurativeRewardNotFoundException is thrown")]
    public async Task
        There_Is_No_Durative_Reward_When_It_Gets_Updated_Then_DurativeRewardNotFoundException_Is_Thrown_Async()
    {
        var useCase = new UpdateDurativeRewardUseCase(Substitute.For<IDurativeRewardRepository>());

        var request = Builder<UpdateDurativeRewardRequest>.CreateNew().Build();


        var action = () => useCase.HandleAsync(request);


        await action.Should().ThrowExactlyAsync<DurativeRewardNotFoundException>();
    }
}