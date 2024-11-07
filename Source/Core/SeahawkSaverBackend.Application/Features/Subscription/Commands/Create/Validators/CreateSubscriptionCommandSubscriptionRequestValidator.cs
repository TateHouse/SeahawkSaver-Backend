namespace SeahawkSaverBackend.Application.Features.Subscription.Commands.Create.Validators;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.Subscription.Commands.Create.DTOs;

/**
 * <summary>
 * A validator for the <see cref="CreateSubscriptionCommandSubscriptionRequest"/>.
 * </summary>
 */
public sealed class CreateSubscriptionCommandSubscriptionRequestValidator : AbstractValidator<CreateSubscriptionCommandSubscriptionRequest>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateSubscriptionCommandSubscriptionRequestValidator"/> instance.
	 * </summary>
	 */
	public CreateSubscriptionCommandSubscriptionRequestValidator()
	{
		RuleFor(request => (decimal?)request.Amount)
			.ValidateAmount();

		RuleFor(request => (DateTime?)request.DateTime)
			.ValidateDateTime();
	}
}