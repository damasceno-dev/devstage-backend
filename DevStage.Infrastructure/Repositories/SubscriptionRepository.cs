using DevStage.Domain.Entities;
using DevStage.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevStage.Infrastructure.Repositories;

public class SubscriptionRepository(DevStageDbContext dbContext) : ISubscriptionRepository
{
    public async Task Register(Subscription subscription)
    {
        await dbContext.Subscriptions.AddAsync(subscription); 
    }

    public async Task<bool> VerifyIfEmailAlreadyExists(string email)
    {
        return await dbContext.Subscriptions.AnyAsync(s => s.Email.ToLower() == email.ToLower());
    }
}