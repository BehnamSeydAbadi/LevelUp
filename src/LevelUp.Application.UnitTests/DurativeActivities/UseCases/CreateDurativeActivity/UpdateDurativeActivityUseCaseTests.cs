using LevelUp.Application.DurativeActivities.UseCases.UpdateDurativeActivity;
using LevelUp.Domain.DurativeActivities;

namespace LevelUp.Application.UnitTests.DurativeActivities.UseCases.CreateDurativeActivity;

public class UpdateDurativeActivityUseCaseTests
{
    [Fact(DisplayName = "There is a durative activity, When it gets updated, Then it is done successfully")]
    public async Task There_Is_A_Durative_Activity_When_It_Gets_Updated_Then_It_Is_Done_Successfully_Async()
    {
        var entity = Builder<DurativeActivity>.CreateNew().Build();

        var mockActivityRepository = Substitute.For<IDurativeActivityRepository>();

        mockActivityRepository.GetAsync(Arg.Any<Guid>()).Returns(entity);

        DurativeActivity? updatedEntity = null;

        mockActivityRepository
            .When(ar => ar.Update(Arg.Any<DurativeActivity>()))
            .Do(ci => updatedEntity = ci.Arg<DurativeActivity>());

        var useCase = new UpdateDurativeActivityUseCase(mockActivityRepository);

        var request = Builder<UpdateDurativeActivityRequest>.CreateNew()
            .With(r => r.Id = entity.Id)
            .Build();


        await useCase.HandleAsync(request);


        updatedEntity.Should().NotBeNull();
        updatedEntity.Id.Should().Be(entity.Id);
        updatedEntity.Name.Should().Be(request.Name);
        updatedEntity.Date.Should().Be(request.Date);
        updatedEntity.Duration.Should().Be(request.Duration);
        updatedEntity.Category.Should().Be(request.Category);
    }
}