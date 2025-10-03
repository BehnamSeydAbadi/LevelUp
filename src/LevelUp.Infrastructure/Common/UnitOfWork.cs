using LevelUp.Application.Common;

namespace LevelUp.Infrastructure.Common;

internal class UnitOfWork(LevelUpDbContext dbContext) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken? cancellationToken)
    {
        await dbContext.SaveChangesAsync(cancellationToken ?? CancellationToken.None);
    }
}