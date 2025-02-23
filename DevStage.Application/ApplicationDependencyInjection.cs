using DevStage.Application.Services;
using DevStage.Application.UseCases.Invites.AccessInvite;
using DevStage.Application.UseCases.Invites.GetTotalInvites;
using DevStage.Application.UseCases.Subscriptions.GetTotalSubscriptions;
using DevStage.Application.UseCases.Subscriptions.Register;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevStage.Application;

public static class ApplicationDependencyInjection
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddUseCases(services);
        AddServices(services, configuration);
    }

    private static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        var webUrl = configuration.GetValue<string>("Services:WebUrl");
        if (string.IsNullOrEmpty(webUrl))
        {
            throw new ArgumentException("Invalid web url");
        }
        services.AddScoped(options => new GetWebUrl(webUrl));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<RegisterSubscriptionUseCase>();
        services.AddScoped<GetTotalSubscriptionsUseCase>();
        services.AddScoped<AccessInviteLinkUseCase>();
        services.AddScoped<GetTotalInvitesUseCase>();
    }
}