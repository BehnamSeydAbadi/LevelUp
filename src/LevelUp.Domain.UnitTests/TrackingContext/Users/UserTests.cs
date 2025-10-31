using LevelUp.Domain.TrackingContext.Users;
using LevelUp.Domain.TrackingContext.Users.Events;
using LevelUp.Domain.TrackingContext.Users.ValueObjects;

namespace LevelUp.Domain.UnitTests.TrackingContext.Users;

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
        var user = Builder<User>.CreateNew().Build();

        var activityId = Guid.NewGuid();
        var date = DateTimeOffset.Now;


        user.PerformActionActivity(activityId, date);


        user.PerformedActivities.Should().NotBeEmpty();
        user.PerformedActivities.Should().HaveCount(1);
        user.PerformedActivities.Single().Id.Should().NotBe(Guid.Empty);
        user.PerformedActivities.Single().ActivityId.Should().Be(activityId);
        user.PerformedActivities.Single().PerformedAt.Should().Be(date);
        user.PerformedActivities.Single().Duration.Should().BeNull();

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
        var user = Builder<User>.CreateNew().Build();

        var activityId = Guid.NewGuid();
        var date = DateTimeOffset.Now;
        var duration = new TimeSpan(hours: 0, minutes: 20, seconds: 0);


        user.PerformDurativeActivity(activityId, date, duration);


        user.PerformedActivities.Should().NotBeEmpty();
        user.PerformedActivities.Should().HaveCount(1);
        user.PerformedActivities.Single().Id.Should().NotBe(Guid.Empty);
        user.PerformedActivities.Single().ActivityId.Should().Be(activityId);
        user.PerformedActivities.Single().PerformedAt.Should().Be(date);
        user.PerformedActivities.Single().Duration.Should().Be(duration);

        var domainEvents = user.GetQueuedEvents();
        domainEvents.Should().NotBeEmpty();

        var @event = domainEvents.OfType<UserPerformedADurativeActivity>().SingleOrDefault();
        @event.Should().NotBeNull();
        @event!.Id.Should().Be(user.Id);
        @event.ActivityId.Should().Be(activityId);
        @event.Duration.Should().Be(duration);
        @event.CreationDateTime.Should().BeCloseTo(DateTimeOffset.Now, TimeSpan.FromSeconds(5));
    }

    [Fact(DisplayName =
        "There is a registered user, When the user achieves a durative reward, Then it is done successfully")]
    public void There_Is_A_Registered_User_When_The_User_Achieves_A_Durative_Reward_Then_It_Is_Done_Successfully()
    {
        var user = Builder<User>.CreateNew().Build();

        var rewardId = Guid.NewGuid();
        var duration = new TimeSpan(hours: 0, minutes: 20, seconds: 0);

        user.AchieveDurativeReward(rewardId, duration);

        user.AchievedRewards.Should().NotBeEmpty();
        user.AchievedRewards.Should().HaveCount(1);
        user.AchievedRewards.Single().Id.Should().NotBe(Guid.Empty);
        user.AchievedRewards.Single().RewardId.Should().Be(rewardId);
        user.AchievedRewards.Single().Duration.Should().Be(duration);
        user.AchievedRewards.Single().AchievedAt.Should().BeCloseTo(DateTimeOffset.Now, TimeSpan.FromSeconds(5));
    }

    [Fact(DisplayName =
        "There is a registered user, When the user achieves an action reward, Then it is done successfully")]
    public void There_Is_A_Registered_User_When_The_User_Achieves_An_Action_Reward_Then_It_Is_Done_Successfully()
    {
        var user = Builder<User>.CreateNew().Build();

        var rewardId = Guid.NewGuid();

        user.AchieveActionReward(rewardId);

        user.AchievedRewards.Should().NotBeEmpty();
        user.AchievedRewards.Should().HaveCount(1);
        user.AchievedRewards.Single().Id.Should().NotBe(Guid.Empty);
        user.AchievedRewards.Single().RewardId.Should().Be(rewardId);
        user.AchievedRewards.Single().AchievedAt.Should().BeCloseTo(DateTimeOffset.Now, TimeSpan.FromSeconds(5));
    }

    [Fact(DisplayName =
        "There is a registered user, When the user uses an action reward, Then it is done successfully")]
    public void There_Is_A_Registered_User_When_The_User_Uses_An_Action_Reward_Then_It_Is_Done_Successfully()
    {
        var user = Builder<User>.CreateNew().Build();

        var rewardId = Guid.NewGuid();
        user.AchieveActionReward(rewardId);


        user.UseActionReward(rewardId);


        user.AchievedRewards.Should().NotBeEmpty();
        user.AchievedRewards.Single().IsUsed.Should().BeTrue();
        user.AchievedRewards.Single().UsedAt.Should().BeCloseTo(DateTimeOffset.Now, TimeSpan.FromSeconds(5));
    }

    [Fact(DisplayName =
        "There is a registered user, When the user uses all of a durative reward, Then it is done successfully")]
    public void There_Is_A_Registered_User_When_The_User_Uses_All_Of_A_Durative_Reward_Then_It_Is_Done_Successfully()
    {
        var user = Builder<User>.CreateNew().Build();

        var rewardId = Guid.NewGuid();
        var duration = TimeSpan.FromMinutes(30);
        user.AchieveDurativeReward(rewardId, duration);


        user.UseDurativeReward(rewardId, duration);


        user.AchievedRewards.Should().NotBeEmpty();
        var usedReward = user.AchievedRewards.Single();
        usedReward.IsUsed.Should().BeTrue();
        usedReward.UsedAt.Should().BeCloseTo(DateTimeOffset.Now, TimeSpan.FromSeconds(5));
        usedReward.Duration!.Value.Hours.Should().Be(0);
        usedReward.Duration.Value.Minutes.Should().Be(0);
        usedReward.Duration.Value.Seconds.Should().Be(0);
    }

    [Fact(DisplayName =
        "There is a registered user, When the user partially uses a durative reward, Then only used duration deducted successfully")]
    public void
        There_Is_A_Registered_User_When_The_User_Partially_Uses_A_Durative_Reward_Then_Only_Used_Duration_Deducted_Successfully()
    {
        var user = Builder<User>.CreateNew().Build();

        var rewardId = Guid.NewGuid();
        var rewardDuration = TimeSpan.FromMinutes(30);
        user.AchieveDurativeReward(rewardId, rewardDuration);

        var usedDuration = TimeSpan.FromMinutes(10);

        user.UseDurativeReward(rewardId, usedDuration);


        user.AchievedRewards.Should().NotBeEmpty();
        var usedReward = user.AchievedRewards.Single();
        usedReward.IsUsed.Should().BeFalse();
        usedReward.UsedAt.Should().BeCloseTo(DateTimeOffset.Now, TimeSpan.FromSeconds(5));
        usedReward.Duration!.Value.Hours.Should().Be(0);
        usedReward.Duration.Value.Minutes.Should().Be(20);
        usedReward.Duration.Value.Seconds.Should().Be(0);
    }

    [Fact(DisplayName =
        "There is a registered user with some action reward achievements, When the user uses an action reward, Then the oldest reward is used successfully")]
    public void
        There_Is_A_Registered_User_With_Some_Action_Reward_Achievements_When_The_User_Uses_An_Action_Reward_Then_The_Oldest_Reward_Is_Used_Successfully()
    {
        var user = Builder<User>.CreateNew().Build();

        var rewardId = Guid.NewGuid();
        user.AchieveActionReward(rewardId);
        user.AchieveActionReward(rewardId);
        user.AchieveActionReward(rewardId);


        user.UseActionReward(rewardId);


        user.AchievedRewards.Should().HaveCount(3);

        var userRewardsOrderedByAchievedAt = user.AchievedRewards.OrderBy(ur => ur.AchievedAt).ToArray();

        userRewardsOrderedByAchievedAt[0].IsUsed.Should().BeTrue();
        userRewardsOrderedByAchievedAt[0].UsedAt.Should().BeCloseTo(DateTimeOffset.Now, TimeSpan.FromSeconds(5));

        userRewardsOrderedByAchievedAt[1].IsUsed.Should().BeFalse();
        userRewardsOrderedByAchievedAt[1].UsedAt.Should().BeNull();

        userRewardsOrderedByAchievedAt[2].IsUsed.Should().BeFalse();
        userRewardsOrderedByAchievedAt[2].UsedAt.Should().BeNull();
    }
}