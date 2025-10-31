using LevelUp.Domain.Users;
using LevelUp.Domain.Users.Events;
using LevelUp.Domain.Users.ValueObjects;

namespace LevelUp.Domain.UnitTests.Users;

public class UserTests
{
    [Fact(DisplayName = "When a user is registered, Then it is done successfully")]
    public void When_A_User_Is_Registered_Then_It_Is_Done_Successfully()
    {
        const string email = "unknown@mail.com";
        const string password = "password";

        var user = User.Register(email, password);

        user.Id.Should().NotBe(Guid.Empty);
        user.Email.Should().Be(EmailValueObject.Create(email));
        user.Password.Should().Be(password);
    }

    [Fact(DisplayName =
        "There is a registered user, When its profile info gets completed, Then it is done successfully")]
    public void There_Is_A_Registered_User_When_Its_Profile_Info_Gets_Completed_Then_It_Is_Done_Successfully()
    {
        var user = Builder<User>.CreateNew().Build();
        const string firstName = "John";
        const string lastName = "Doe";
        var dateOfBirth = new DateTime(1980, 1, 1);
        const string image = "image.jpg";

        user.AddProfileInfo(firstName, lastName, dateOfBirth, image);

        user.Profile.Should().NotBeNull();
        user.Profile.FirstName.Should().Be(firstName);
        user.Profile.LastName.Should().Be(lastName);
        user.Profile.DateOfBirth.Should().Be(dateOfBirth);
        user.Profile.ImageUrl.Should().Be(image);
    }

    [Fact(DisplayName =
        "There is a registered user with profile info, When its profile info gets updated, Then it is done successfully")]
    public void
        There_Is_A_Registered_User_With_Profile_Info_When_Its_Profile_Info_Gets_Updated_Then_It_Is_Done_Successfully()
    {
        var user = Builder<User>.CreateNew()
            .With(u => u.Profile = Builder<UserProfileValueObject>.CreateNew().Build())
            .Build();

        const string firstName = "John";
        const string lastName = "Doe";
        var dateOfBirth = new DateTime(1980, 1, 1);
        const string image = "image.jpg";

        user.UpdateProfile(firstName, lastName, dateOfBirth, image);

        user.Profile.Should().NotBeNull();
        user.Profile.FirstName.Should().Be(firstName);
        user.Profile.LastName.Should().Be(lastName);
        user.Profile.DateOfBirth.Should().Be(dateOfBirth);
        user.Profile.ImageUrl.Should().Be(image);
    }

    [Fact(DisplayName =
        "There is a registered user, When the user performs an action activity, Then it is done successfully")]
    public void There_Is_A_Registered_User_When_The_User_Performs_An_Action_Activity_Then_It_Is_Done_Successfully()
    {
        var user = Builder<User>.CreateNew()
            .With(u => u.Profile = Builder<UserProfileValueObject>.CreateNew().Build())
            .Build();

        var activityId = Guid.NewGuid();
        var date = DateTimeOffset.Now;


        user.PerformActionActivity(activityId, date);


        user.Activities.Should().NotBeEmpty();
        user.Activities.Should().HaveCount(1);
        user.Activities.Single().Id.Should().NotBe(Guid.Empty);
        user.Activities.Single().ActivityId.Should().Be(activityId);
        user.Activities.Single().Date.Should().Be(date);
        user.Activities.Single().Duration.Should().BeNull();

        var domainEvents = user.GetQueuedEvents();
        domainEvents.Should().NotBeEmpty();

        var @event = domainEvents.OfType<UserPerformedAnActionActivity>().SingleOrDefault();
        @event.Should().NotBeNull();
        @event!.Id.Should().Be(user.Id);
        @event.ActivityId.Should().Be(activityId);
        @event.CreationDateTime.Should().BeCloseTo(DateTimeOffset.Now, TimeSpan.FromSeconds(5));
    }


    [Fact(DisplayName =
        "There is a registered user, When the user performs a durative activity, Then it is done successfully")]
    public void There_Is_A_Registered_User_When_The_User_Performs_A_Durative_Activity_Then_It_Is_Done_Successfully()
    {
        var user = Builder<User>.CreateNew()
            .With(u => u.Profile = Builder<UserProfileValueObject>.CreateNew().Build())
            .Build();

        var activityId = Guid.NewGuid();
        var date = DateTimeOffset.Now;
        var duration = new TimeSpan(hours: 0, minutes: 20, seconds: 0);


        user.PerformDurativeActivity(activityId, date, duration);


        user.Activities.Should().NotBeEmpty();
        user.Activities.Should().HaveCount(1);
        user.Activities.Single().Id.Should().NotBe(Guid.Empty);
        user.Activities.Single().ActivityId.Should().Be(activityId);
        user.Activities.Single().Date.Should().Be(date);
        user.Activities.Single().Duration.Should().Be(duration);

        var domainEvents = user.GetQueuedEvents();
        domainEvents.Should().NotBeEmpty();

        var @event = domainEvents.OfType<UserPerformedADurativeActivity>().SingleOrDefault();
        @event.Should().NotBeNull();
        @event!.Id.Should().Be(user.Id);
        @event.ActivityId.Should().Be(activityId);
        @event.Duration.Should().Be(duration);
        @event.CreationDateTime.Should().BeCloseTo(DateTimeOffset.Now, TimeSpan.FromSeconds(5));
    }
}