using ApplicationException = LevelUp.Application.Common.Exceptions.ApplicationException;

namespace LevelUp.Application.DurativeRewards.Exceptions;

public class DurativeRewardNotFoundException() : ApplicationException(message: "Durative reward not found");