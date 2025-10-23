using LevelUp.Domain.Users.Exceptions;
using LevelUp.Domain.Users.ValueObjects;

namespace LevelUp.Domain.UnitTests.Users;

public class EmailValueObjectTests
{
    [Fact(DisplayName = "When an email is created by a correct value, Then it is done successfully")]
    public void When_An_Email_Is_Created_By_A_Correct_Value_Then_It_Is_Done_Successfully()
    {
        const string emailAddress = "unknown@mail.com";

        var valueObject = EmailValueObject.Create(emailAddress);

        valueObject.Value.Should().Be(emailAddress);
    }

    [Theory(DisplayName = "When an email gets created by incorrect values, Then an exception is thrown")]
    [InlineData("unknown.com")]
    [InlineData("unknown")]
    [InlineData("mail.com")]
    [InlineData(".com")]
    public void When_An_Email_Gets_Created_By_Incorrect_Values_Then_An_Exception_Is_Thrown(string emailAddress)
    {
        var action = () => EmailValueObject.Create(emailAddress);

        action.Should().ThrowExactly<InvalidEmailException>();
    }
}