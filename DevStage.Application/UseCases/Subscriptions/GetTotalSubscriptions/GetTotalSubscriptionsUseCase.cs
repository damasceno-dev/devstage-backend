using DevStage.Communication.Responses;
using DevStage.Domain.Interfaces;
using DevStage.Exception;

namespace DevStage.Application.UseCases.Subscriptions.GetTotalSubscriptions;

public class GetTotalSubscriptionsUseCase(ISubscriptionRepository subscriptionRepository)
{
    public async Task<ResponseSubscriberTotalSubscriptions> Execute(Guid subscriberId)
    {
        var idExists = await subscriptionRepository.VerifyIfIdExists(subscriberId);
        if (idExists is false)
        {
            throw new NotFoundException(ResourcesErrorMessages.SubscriptionNotFound);
        }
        var totalSubscription =await subscriptionRepository.GetTotalReferralSubscription(subscriberId);
        return totalSubscription.ToResponse();
    }
}