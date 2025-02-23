using DevStage.Communication.Requests;
using DevStage.Communication.Responses;
using DevStage.Domain.Entities;

namespace DevStage.Application.UseCases.Subscriptions.Register;

public static class RegisterSubscriptionMapper
{
    public static Subscription ToDomain(this RequestRegisterSubscriptionJson request)
    {
        return new Subscription
        {
            Name = request.Name,
            Email = request.Email
        };
    }

    public static ResponseRegisterSubscriptionJson ToResponse(this Subscription subscription)
    {
        return new ResponseRegisterSubscriptionJson
        {
            Id = subscription.Id,
            Name = subscription.Name,
            Email = subscription.Email
        };
    }
}