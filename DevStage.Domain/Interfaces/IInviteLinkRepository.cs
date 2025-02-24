using DevStage.Domain.Entities;

namespace DevStage.Domain.Interfaces;

public interface IInviteLinkRepository
{
    Task RegisterInvite(Invite subscriberId);
    Task<int> GetTotalInvitesClicks(Guid subscriberId);
}