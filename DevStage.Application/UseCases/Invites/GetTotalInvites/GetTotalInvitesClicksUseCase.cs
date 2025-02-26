using DevStage.Communication.Responses;
using DevStage.Domain.Interfaces;
using DevStage.Exception;

namespace DevStage.Application.UseCases.Invites.GetTotalInvites;

public class GetTotalInvitesClicksUseCase(IInviteLinkRepository inviteLinkRepository, ISubscriptionRepository subscriptionRepository)
{
    public async Task<ResponseSubscriberTotalInvitesJson> Execute(Guid subscriberId)
    {
        var idExists = await subscriptionRepository.VerifyIfIdExists(subscriberId);
        if (idExists is false)
        {
            throw new NotFoundException(ResourcesErrorMessages.SubscriptionNotFound);
        }
        var totalInvites =await inviteLinkRepository.GetTotalInvitesClicks(subscriberId);
        return totalInvites.ToResponse();
    }
}