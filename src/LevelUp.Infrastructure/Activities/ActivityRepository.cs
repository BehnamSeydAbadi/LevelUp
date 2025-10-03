using LevelUp.Domain.Activities;

namespace LevelUp.Infrastructure.Activities;

public class ActivityRepository(LevelUpDbContext dbContext) : IActivityRepository
{
    public void Add(Activity activity)
    {
        dbContext.Set<Activity>().Add(activity);
    }
}