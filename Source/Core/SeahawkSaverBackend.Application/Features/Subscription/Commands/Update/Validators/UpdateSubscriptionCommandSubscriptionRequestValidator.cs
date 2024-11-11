namespace SeahawkSaverBackend.Application.Features.Subscription.Commands.Update.Validators;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.Subscription.Commands.Update.DTOs;

/**
 * <summary>
 * A validator for the <see cref="UpdateSubscriptionCommandSubscriptionRequest"/>.
 * </summary>
 */
public sealed class UpdateSubscriptionCommandSubscriptionRequestValidator : AbstractValidator<UpdateSubscriptionCommandSubscriptionRequest>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateSubscriptionCommandSubscriptionRequestValidator"/> instance.
	 * </summary>
	 */
	public UpdateSubscriptionCommandSubscriptionRequestValidator()
	{
		RuleFor(request => (Guid?)request.UserId)
			.ValidateUserId();

		RuleFor(request => (Guid?)request.SubscriptionId)
			.ValidateSubscriptionId();

		RuleFor(request => (decimal?)request.Amount)
			.ValidateAmount();

		RuleFor(request => (DateTime?)request.DateTime)
			.ValidateDateTime();
	}
}