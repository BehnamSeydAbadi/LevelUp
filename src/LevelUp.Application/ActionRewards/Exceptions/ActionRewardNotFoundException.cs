using ApplicationException = LevelUp.Application.Common.Exceptions.ApplicationException;

namespace LevelUp.Application.ActionRewards.Exceptions;

public class ActionRewardNotFoundException() : ApplicationException(message: "Action reward not found");