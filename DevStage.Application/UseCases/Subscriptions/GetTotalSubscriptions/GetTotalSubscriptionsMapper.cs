using DevStage.Communication.Responses;

namespace DevStage.Application.UseCases.Subscriptions.GetTotalSubscriptions;

public static class GetTotalSubscriptionsMapper
{
    public static ResponseSubscriberTotalSubscriptions ToResponse(this int totalSubscriptions)
    {
        return new ResponseSubscriberTotalSubscriptions
        {
            TotalSubscriptions = totalSubscriptions
        };
    }
}