using LevelUp.Domain.Common.Exceptions;

namespace LevelUp.Domain.Users.Exceptions;

public class InvalidEmailException() : DomainException(message: "Invalid email address");