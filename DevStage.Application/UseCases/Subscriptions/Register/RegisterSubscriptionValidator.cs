using DevStage.Application.Services;
using DevStage.Communication.Requests;
using DevStage.Exception;
using FluentValidation;

namespace DevStage.Application.UseCases.Subscriptions.Register;

public class RegisterSubscriptionValidator : AbstractValidator<RequestRegisterSubscriptionJson>
{
    public RegisterSubscriptionValidator()
    {
        RuleFor(r => r.Name).NotEmpty().WithMessage(ResourcesErrorMessages.NameNotEmpty);
        RuleFor(r => r.Name).MaximumLength(SharedValidators.MaximumNameLength).WithMessage(ResourcesErrorMessages.NameTooLong);
        RuleFor(r => r.Email).EmailAddress().WithMessage(ResourcesErrorMessages.EmailInvalid);
    }
}