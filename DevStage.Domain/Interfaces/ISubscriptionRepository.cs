using DevStage.Domain.Entities;

namespace DevStage.Domain.Interfaces;

public interface ISubscriptionRepository
{
    Task Register(Subscription subscription);
    Task<bool> VerifyIfEmailAlreadyExists(string email);
    Task<bool> VerifyIfIdAlreadyExists(Guid id);
    Task<int> GetTotalReferralSubscription(Guid subscriberId);
}