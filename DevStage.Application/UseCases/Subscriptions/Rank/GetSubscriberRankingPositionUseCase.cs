using DevStage.Communication.Responses;
using DevStage.Domain.Interfaces;
using DevStage.Exception;

namespace DevStage.Application.UseCases.Subscriptions.Rank;

public class GetSubscriberRankingPositionUseCase(ISubscriptionRepository subscriptionRepository)
{
    public async Task<ResponseSubscriberRankingPositionJson> Execute(Guid subscriberId)
    {
        var idExists = await subscriptionRepository.VerifyIfIdExists(subscriberId);
        if (idExists is false)
        {
            throw new NotFoundException(ResourcesErrorMessages.SubscriptionNotFound);
        }
        var rankingPosition =await subscriptionRepository.GetReferralRank(subscriberId);
        return rankingPosition.ToResponse();
    }
}