using DevStage.Communication.Responses;
using DevStage.Domain.Interfaces;
using DevStage.Exception;

namespace DevStage.Application.UseCases.Invites.GetTotalInvites;

public class GetTotalInvitesUseCase(IInviteLinkRepository inviteLinkRepository, ISubscriptionRepository subscriptionRepository)
{
    public async Task<ResponseSusbcriberTotalInvites> Execute(Guid subscriberId)
    {
        var idExists = await subscriptionRepository.VerifyIfIdAlreadyExists(subscriberId);
        if (idExists is false)
        {
            throw new NotFoundException(ResourcesErrorMessages.SubscriptionNotFound);
        }
        var totalInvites =await inviteLinkRepository.GetTotalInvites(subscriberId);
        return totalInvites.ToResponse();
    }
}