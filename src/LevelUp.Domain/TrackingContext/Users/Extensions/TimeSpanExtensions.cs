namespace LevelUp.Domain.TrackingContext.Users.Extensions;

public static class TimeSpanExtensions
{
    public static bool IsTotallyZero(this TimeSpan timeSpan) => timeSpan.TotalNanoseconds == 0;
    public static bool IsLowerThanZero(this TimeSpan timeSpan) => timeSpan.TotalNanoseconds < 0;
}