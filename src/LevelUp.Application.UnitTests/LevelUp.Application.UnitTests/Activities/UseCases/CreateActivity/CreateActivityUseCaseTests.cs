using LevelUp.Application.Activities.UseCases.CreateActivity;
using LevelUp.Domain.Activities.Events;
using LevelUp.Domain.Common;

namespace LevelUp.Application.UnitTests.Activities.UseCases.CreateActivity;

public class CreateActivityUseCaseTests
{
    [Fact(DisplayName = "When an activity is created, Then it is done successfully")]
    public async Task When_An_Activity_Is_Created_Then_It_Is_Done_Successfully_Async()
    {
        var eventPublisher = Substitute.For<IEventPublisher>();

        IDomainEvent[]? domainEvents = null;

        eventPublisher.When(ep => ep.PublishAsync(Arg.Any<IDomainEvent[]>()))
            .Do(ci => domainEvents = ci.Arg<IDomainEvent[]>());

        var useCase = new CreateActivityUseCase(eventPublisher);

        var dto = Builder<CreateActivityUseCaseDto>.CreateNew().Build();


        await useCase.HandleAsync(dto);


        domainEvents.Should().NotBeNull();
        domainEvents.Should().HaveCount(1);
        var domainEvent = domainEvents.First() as ActivityCreated;
        domainEvent.Should().NotBeNull();
        domainEvent.AggregateId.Should().NotBe(Guid.Empty);
        domainEvent.Name.Should().Be(dto.Name);
        domainEvent.Date.Should().Be(dto.Date);
        domainEvent.Duration.Should().Be(dto.Duration);
        domainEvent.Category.Should().Be(dto.Category);
    }
}