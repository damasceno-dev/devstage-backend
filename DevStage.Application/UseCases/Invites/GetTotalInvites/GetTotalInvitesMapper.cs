using DevStage.Communication.Responses;

namespace DevStage.Application.UseCases.Invites.GetTotalInvites;

public static class GetTotalInvitesMapper
{
    public static ResponseSubscriberTotalInvitesJson ToResponse(this int totalInvites)
    {
        return new ResponseSubscriberTotalInvitesJson
        {
            TotalInvites = totalInvites
        };
    }
}