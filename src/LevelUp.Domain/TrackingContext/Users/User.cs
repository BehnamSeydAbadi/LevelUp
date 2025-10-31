using LevelUp.Domain.Common;
using LevelUp.Domain.TrackingContext.Users.Events;
using LevelUp.Domain.TrackingContext.Users.ValueObjects;

namespace LevelUp.Domain.TrackingContext.Users;

public class User : AggregateRoot<Guid>
{
    private readonly List<UserActivity> _performedActivities = [];
    private readonly List<UserReward> _achievedRewards = [];

    public static User Register(string email, string password)
    {
        return new User
        {
            Id = Guid.NewGuid(),
            Email = EmailValueObject.Create(email),
            Password = password
        };
    }

    public EmailValueObject Email { get; set; }
    public string Password { get; set; }
    public UserProfileValueObject? Profile { get; set; }
    public IReadOnlyList<UserActivity> PerformedActivities => _performedActivities;
    public IReadOnlyList<UserReward> AchievedRewards => _achievedRewards;

    public void AddProfileInfo(string firstName, string lastName, DateTime dateOfBirth, string imageUrl)
    {
        Profile = UserProfileValueObject.Create(firstName, lastName, dateOfBirth, imageUrl);
    }

    public void UpdateProfile(string firstName, string lastName, DateTime dateOfBirth, string imageUrl)
    {
        Profile = UserProfileValueObject.Create(firstName, lastName, dateOfBirth, imageUrl);
    }

    public void PerformActionActivity(Guid activityId, DateTimeOffset date)
    {
        _performedActivities.Add(UserActivity.CreateAction(activityId, date));
        QueueEvent(new UserPerformedAnActionActivity(this.Id, activityId));
    }

    public void PerformDurativeActivity(Guid activityId, DateTimeOffset date, TimeSpan duration)
    {
        _performedActivities.Add(UserActivity.CreateDurative(activityId, date, duration));
        QueueEvent(new UserPerformedADurativeActivity(this.Id, activityId, duration));
    }

    public void AchieveDurativeReward(Guid rewardId, TimeSpan duration)
    {
        _achievedRewards.Add(UserReward.CreateDurative(rewardId, duration));
    }

    public void AchieveActionReward(Guid rewardId)
    {
        _achievedRewards.Add(UserReward.CreateAction(rewardId));
    }
}