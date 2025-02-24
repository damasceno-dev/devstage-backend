using DevStage.Communication.Responses;
using DevStage.Domain.Interfaces;
using DevStage.Exception;

namespace DevStage.Application.UseCases.Subscriptions.Rank;

public class GetRankUseCase(ISubscriptionRepository subscriptionRepository)
{
    public async Task<ResponseRank> Execute()
    {
        var rank =await subscriptionRepository.GetRank();
        return rank.ToResponse();
    }
}