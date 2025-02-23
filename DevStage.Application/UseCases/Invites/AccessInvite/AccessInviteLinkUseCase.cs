using DevStage.Application.Services;
using DevStage.Domain.Entities;
using DevStage.Domain.Interfaces;

namespace DevStage.Application.UseCases.Invites.AccessInvite;

public class AccessInviteLinkUseCase(IInviteLinkRepository inviteLinkRepository, IUnitOfWork unitOfWork, GetWebUrl url)
{
    public async Task<string> Execute(Guid subscriberId)
    {
        var newInvite = new Invite {SubscriberId = subscriberId};
        await inviteLinkRepository.RegisterInvite(newInvite);
        await unitOfWork.Commit();
        
        return url.WebUrl;
    }
}