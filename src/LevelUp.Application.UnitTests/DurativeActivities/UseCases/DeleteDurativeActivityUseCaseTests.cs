using LevelUp.Application.DurativeActivities.Exceptions;
using LevelUp.Application.DurativeActivities.UseCases.DeleteDurativeActivity;
using LevelUp.Domain.DurativeActivities;

namespace LevelUp.Application.UnitTests.DurativeActivities.UseCases;

public class DeleteDurativeActivityUseCaseTests
{
    [Fact(DisplayName = "There is a durative activity, When it gets deleted, Then it is done successfully")]
    public async Task There_Is_A_Durative_Activity_When_It_Gets_Deleted_Then_It_Is_Done_Successfully_Async()
    {
        var entity = Builder<DurativeActivity>.CreateNew().Build();

        var mockActivityRepository = Substitute.For<IDurativeActivityRepository>();

        mockActivityRepository.GetAsync(Arg.Any<Guid>()).Returns(entity);

        DurativeActivity? deletedEntity = null;

        mockActivityRepository
            .When(ar => ar.Delete(Arg.Any<DurativeActivity>()))
            .Do(ci => deletedEntity = ci.Arg<DurativeActivity>());

        var useCase = new DeleteDurativeActivityUseCase(mockActivityRepository);

        var request = Builder<DeleteDurativeActivityRequest>.CreateNew()
            .With(r => r.Id = entity.Id)
            .Build();


        await useCase.HandleAsync(request);


        deletedEntity.Should().NotBeNull();
        deletedEntity.Id.Should().Be(entity.Id);
    }

    [Fact(DisplayName =
        "There is no durative activity, When it gets deleted,  Then DurativeActivityNotFoundException is thrown")]
    public async Task
        There_Is_No_Durative_Activity_When_It_Gets_Deleted_Then_DurativeActivityNotFoundException_Is_Thrown_Async()
    {
        var useCase = new DeleteDurativeActivityUseCase(Substitute.For<IDurativeActivityRepository>());

        var request = Builder<DeleteDurativeActivityRequest>.CreateNew().Build();


        var action = () => useCase.HandleAsync(request);


        await action.Should().ThrowExactlyAsync<DurativeActivityNotFoundException>();
    }
}