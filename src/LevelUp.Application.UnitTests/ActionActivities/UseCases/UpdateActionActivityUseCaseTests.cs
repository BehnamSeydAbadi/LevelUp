using LevelUp.Application.ActionActivities.Exceptions;
using LevelUp.Application.ActionActivities.UseCases.UpdateActionActivity;
using LevelUp.Domain.ActionActivities;

namespace LevelUp.Application.UnitTests.ActionActivities.UseCases;

public class UpdateActionActivityUseCaseTests
{
    [Fact(DisplayName = "There is an action activity, When it gets updated, Then it is done successfully")]
    public async Task There_Is_An_Action_Activity_When_It_Gets_Updated_Then_It_Is_Done_Successfully_Async()
    {
        var entity = Builder<ActionActivity>.CreateNew().Build();

        var mockActivityRepository = Substitute.For<IActionActivityRepository>();

        mockActivityRepository.GetAsync(Arg.Any<Guid>()).Returns(entity);

        ActionActivity? updatedEntity = null;

        mockActivityRepository
            .When(ar => ar.Update(Arg.Any<ActionActivity>()))
            .Do(ci => updatedEntity = ci.Arg<ActionActivity>());

        var useCase = new UpdateActionActivityUseCase(mockActivityRepository);

        var request = Builder<UpdateActionActivityRequest>.CreateNew()
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
        "There is no action activity, When it gets updated, Then ActionActivityNotFoundException is thrown")]
    public async Task
        There_Is_No_Action_Activity_When_It_Gets_Updated_Then_ActionActivityNotFoundException_Is_Thrown_Async()
    {
        var useCase = new UpdateActionActivityUseCase(Substitute.For<IActionActivityRepository>());

        var request = Builder<UpdateActionActivityRequest>.CreateNew().Build();


        var action = () => useCase.HandleAsync(request);


        await action.Should().ThrowExactlyAsync<ActionActivityNotFoundException>();
    }
}