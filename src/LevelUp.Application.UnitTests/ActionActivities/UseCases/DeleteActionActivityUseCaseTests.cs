using LevelUp.Application.ActionActivities.Exceptions;
using LevelUp.Application.ActionActivities.UseCases.DeleteActionActivity;
using LevelUp.Domain.ActionActivities;

namespace LevelUp.Application.UnitTests.ActionActivities.UseCases;

public class DeleteActionActivityUseCaseTests
{
    [Fact(DisplayName = "There is an action activity, When it gets deleted, Then it is done successfully")]
    public async Task There_Is_An_Action_Activity_When_It_Gets_Deleted_Then_It_Is_Done_Successfully_Async()
    {
        var entity = Builder<ActionActivity>.CreateNew().Build();

        var mockActivityRepository = Substitute.For<IActionActivityRepository>();

        mockActivityRepository.GetAsync(Arg.Any<Guid>()).Returns(entity);

        ActionActivity? deletedEntity = null;

        mockActivityRepository
            .When(ar => ar.Delete(Arg.Any<ActionActivity>()))
            .Do(ci => deletedEntity = ci.Arg<ActionActivity>());

        var useCase = new DeleteActionActivityUseCase(mockActivityRepository);

        var request = Builder<DeleteActionActivityRequest>.CreateNew()
            .With(r => r.Id = entity.Id)
            .Build();


        await useCase.HandleAsync(request);


        deletedEntity.Should().NotBeNull();
        deletedEntity.Id.Should().Be(entity.Id);
    }

    [Fact(DisplayName =
        "There is no action activity, When it gets deleted,  Then ActionActivityNotFoundException is thrown")]
    public async Task
        There_Is_No_Action_Activity_When_It_Gets_Deleted_Then_ActionActivityNotFoundException_Is_Thrown_Async()
    {
        var useCase = new DeleteActionActivityUseCase(Substitute.For<IActionActivityRepository>());

        var request = Builder<DeleteActionActivityRequest>.CreateNew().Build();


        var action = () => useCase.HandleAsync(request);


        await action.Should().ThrowExactlyAsync<ActionActivityNotFoundException>();
    }
}