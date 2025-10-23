using ApplicationException = LevelUp.Application.Common.Exceptions.ApplicationException;

namespace LevelUp.Application.ActionActivities.Exceptions;

public class ActionActivityNotFoundException() : ApplicationException(message: "Action activity not found");