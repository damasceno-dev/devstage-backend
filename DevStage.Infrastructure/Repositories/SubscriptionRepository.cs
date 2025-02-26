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

    public async Task<List<RankDto>> GetRank() { 
        var subscriptions = await dbContext.Subscriptions.ToListAsync(); 
        
        // Calculate referral counts: For each subscriber, count how many times their Id appears as a referral.
        var referralCounts = subscriptions.Where(s => s.ReferredId != null) 
            .GroupBy(s => s.ReferredId!.Value) 
            .ToDictionary(g => g.Key, g => g.Count());
        
        var combinedList = subscriptions.Select(s => new { s.Id, s.CreatedOn, Score = referralCounts.GetValueOrDefault(s.Id, 0) }) 
        // Order first by descending score and then by the creation date (earlier created come first).
        .OrderByDescending(x => x.Score).ThenBy(x => x.CreatedOn).ToList();
        
        var rankList = new List<RankDto>();
        for (var i = 0; i < combinedList.Count; i++)
        {
            rankList.Add(new RankDto(combinedList[i].Id, i + 1, combinedList[i].Score));
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

