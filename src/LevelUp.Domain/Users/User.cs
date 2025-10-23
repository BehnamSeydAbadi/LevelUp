using LevelUp.Domain.Common;
using LevelUp.Domain.Users.ValueObjects;

namespace LevelUp.Domain.Users;

public class User : AggregateRoot<Guid>
{
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
}