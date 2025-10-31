using LevelUp.Domain.Common.Attributes;
using LevelUp.Domain.Common.ValueObjects;

namespace LevelUp.Domain.Users.ValueObjects;

public record UserProfileValueObject : ValueObject
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string ImageUrl { get; private set; }

    public static UserProfileValueObject Create(
        string firstName, string lastName, DateTime dateOfBirth, string imageUrl
    )
    {
        return new UserProfileValueObject(firstName, lastName, dateOfBirth, imageUrl);
    }

    [PersistenceOnlyPurpose]
    protected UserProfileValueObject()
    {
    }

    private UserProfileValueObject(string firstName, string lastName, DateTime dateOfBirth, string imageUrl)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        ImageUrl = imageUrl;
    }
}