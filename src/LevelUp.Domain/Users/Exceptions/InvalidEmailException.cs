using LevelUp.Domain.Common;

namespace LevelUp.Domain.Users.Exceptions;

public class InvalidEmailException() : DomainException(message: "Invalid email address");