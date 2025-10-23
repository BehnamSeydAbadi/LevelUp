using LevelUp.Domain.Users;
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
}