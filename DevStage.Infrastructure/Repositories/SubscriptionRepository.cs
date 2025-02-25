using DevStage.Domain.Dtos;
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

    public async Task<bool> VerifyIfIdExists(Guid id)
    {
        return await dbContext.Subscriptions.AnyAsync(s => s.Id == id);
    }

    public async Task<int> GetTotalReferralSubscription(Guid subscriberId)
    {
        return await dbContext.Subscriptions.CountAsync(subscription => subscription.ReferredId == subscriberId);
    }

    public async Task<List<RankDto>> GetRank()
    {
        var subscriptions = await dbContext.Subscriptions.ToListAsync();
        
        var referralCounts = subscriptions
            .Where(s => s.ReferredId is not null)
            .GroupBy(s => s.ReferredId!.Value)
            .ToDictionary(g => g.Key, g => g.Count());

        // Create an initial list containing the referral count as the score
        var rankList = referralCounts
            .Select(kvp => new RankDto(kvp.Key, 0, kvp.Value))
            .OrderByDescending(dto => dto.Score) // Order descending by score
            .ToList();

        // Assign ranking positions (1-based) based on the score order.
        for (var i = 0; i < rankList.Count; i++)
        {
            rankList[i] = new RankDto(rankList[i].Id, i + 1, rankList[i].Score);
        }
        
        return rankList;
    }

    public async Task<RankDto> GetReferralRank(Guid subscriberId)
    {
        var rankList = await GetRank();
            
        var rankDto = rankList.FirstOrDefault(r => r.Id == subscriberId);

        return rankDto ?? new RankDto(subscriberId, 0, 0);
    }
}

