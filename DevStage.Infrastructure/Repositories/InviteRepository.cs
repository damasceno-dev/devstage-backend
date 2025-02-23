using DevStage.Domain.Entities;
using DevStage.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevStage.Infrastructure.Repositories;

public class InviteRepository(DevStageDbContext dbContext) : IInviteLinkRepository
{
    public async Task RegisterInvite(Invite invite)
    {
        await dbContext.Invites.AddAsync(invite);
    }

    public async Task<int> GetTotalInvites(Guid subscriberId)
    {
        return await dbContext.Invites.CountAsync(invite => invite.SubscriberId == subscriberId);
    }
}