using DevStage.Communication.Responses;

namespace DevStage.Application.UseCases.Invites.GetTotalInvites;

public static class GetTotalInvitesMapper
{
    public static ResponseSusbcriberTotalInvites ToResponse(this int totalInvites)
    {
        return new ResponseSusbcriberTotalInvites
        {
            TotalInvites = totalInvites
        };
    }
}