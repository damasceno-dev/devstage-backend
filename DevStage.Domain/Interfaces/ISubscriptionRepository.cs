using DevStage.Domain.Dtos;
using DevStage.Domain.Entities;

namespace DevStage.Domain.Interfaces;

public interface ISubscriptionRepository
{
    Task Register(Subscription subscription);
    Task<bool> VerifyIfEmailAlreadyExists(string email);
    Task<bool> VerifyIfIdExists(Guid id);
    Task<int> GetTotalReferralSubscription(Guid subscriberId);
    Task<RankDto> GetReferralRank(Guid subscriberId);
    Task<List<RankDto>> GetRank();
    Task<List<RankDto>> GetTopThreeRank();
}