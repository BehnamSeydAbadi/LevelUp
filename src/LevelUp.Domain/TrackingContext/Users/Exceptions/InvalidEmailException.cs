using LevelUp.Domain.Common.Exceptions;

namespace LevelUp.Domain.TrackingContext.Users.Exceptions;

public class InvalidEmailException() : DomainException(message: "Invalid email address");