using System.ComponentModel.DataAnnotations;
using LevelUp.Domain.Common.Attributes;
using LevelUp.Domain.Common.ValueObjects;
using LevelUp.Domain.TrackingContext.Users.Exceptions;

namespace LevelUp.Domain.TrackingContext.Users.ValueObjects;

public record EmailValueObject : ValueObject
{
    public string Value { get; private set; }

    public static EmailValueObject Create(string value)
    {
        return new EmailValueObject(value);
    }

    [PersistenceOnlyPurpose]
    protected EmailValueObject()
    {
    }

    private EmailValueObject(string value)
    {
        if (new EmailAddressAttribute().IsValid(value) is false)
            throw new InvalidEmailException();

        Value = value;
    }
}