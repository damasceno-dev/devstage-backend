using DevStage.Communication.Requests;
using DevStage.Communication.Responses;
using DevStage.Domain.Interfaces;
using DevStage.Domain.Entities;
using DevStage.Exception;

namespace DevStage.Application.UseCases.Subscriptions.Register;

public class RegisterSubscriptionUseCase(ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork)
{
    public async Task<ResponseRegisterSubscriptionJson> Execute(RequestRegisterSubscriptionJson request)
    {
        await Validate(request);
        var subscription = request.ToDomain();
        await subscriptionRepository.Register(subscription);
        await unitOfWork.Commit();
        return subscription.ToResponse();

    }

    private async Task Validate(RequestRegisterSubscriptionJson request)
    {
        var validation = await new RegisterSubscriptionValidator().ValidateAsync(request);
        if (validation.IsValid is false)
        {
            throw new OnValidationException(validation.Errors.Select(e => e.ErrorMessage).ToList());
        }
        
        var emailAlreadyExists = await subscriptionRepository.VerifyIfEmailAlreadyExists(request.Email);
        if (emailAlreadyExists)
        {
            throw new ConflictException(ResourcesErrorMessages.EmailAlreadyExists);
        }

        if (request.ReferredId is not null)
        {
            var referredIdExists = await subscriptionRepository.VerifyIfIdExists(request.ReferredId.Value);
            if (referredIdExists is false)
            {
                throw new NotFoundException(ResourcesErrorMessages.SubscriptionRefferralIdNotFound);
            }
        }

    }
}