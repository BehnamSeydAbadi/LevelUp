using ApplicationException = LevelUp.Application.Common.Exceptions.ApplicationException;

namespace LevelUp.Application.DurativeActivities.Exceptions;

public class DurativeActivityNotFoundException() : ApplicationException(message: "Durative activity not found");