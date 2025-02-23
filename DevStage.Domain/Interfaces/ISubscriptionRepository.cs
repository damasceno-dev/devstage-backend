using DevStage.Domain.Entities;

namespace DevStage.Domain.Interfaces;

public interface ISubscriptionRepository
{
    Task Register(Subscription subscription);
    Task<bool> VerifyIfEmailAlreadyExists(string email);
}