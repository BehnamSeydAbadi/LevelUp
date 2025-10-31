using LevelUp.Domain.Common;
using LevelUp.Domain.Users.Events;
using LevelUp.Domain.Users.ValueObjects;

namespace LevelUp.Domain.Users;

public class User : AggregateRoot<Guid>
{
    private readonly List<UserActivity> _activities = [];

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
    public IReadOnlyList<UserActivity> Activities => _activities;

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
        _activities.Add(UserActivity.PerformAction(activityId, date));
        QueueEvent(new UserPerformedAnActionActivity(this.Id, activityId));
    }

    public void PerformDurativeActivity(Guid activityId, DateTimeOffset date, TimeSpan duration)
    {
        _activities.Add(UserActivity.PerformDurative(activityId, date, duration));
        QueueEvent(new UserPerformedADurativeActivity(this.Id, activityId, duration));
    }
}