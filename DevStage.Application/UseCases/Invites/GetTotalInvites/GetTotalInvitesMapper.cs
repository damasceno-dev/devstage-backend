using DevStage.Communication.Responses;

namespace DevStage.Application.UseCases.Invites.GetTotalInvites;

public static class GetTotalInvitesMapper
{
    public static ResponseSusbcriberTotalInvitesJson ToResponse(this int totalInvites)
    {
        return new ResponseSusbcriberTotalInvitesJson
        {
            TotalInvites = totalInvites
        };
    }
}