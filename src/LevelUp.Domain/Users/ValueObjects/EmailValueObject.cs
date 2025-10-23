using System.ComponentModel.DataAnnotations;
using LevelUp.Domain.Common;
using LevelUp.Domain.Users.Exceptions;

namespace LevelUp.Domain.Users.ValueObjects;

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