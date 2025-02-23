using DevStage.Domain.Interfaces;

namespace DevStage.Infrastructure.Repositories;

public class UnitOfWork(DevStageDbContext dbContext) : IUnitOfWork
{
    public async Task Commit()
    {
        await dbContext.SaveChangesAsync();
    }
}