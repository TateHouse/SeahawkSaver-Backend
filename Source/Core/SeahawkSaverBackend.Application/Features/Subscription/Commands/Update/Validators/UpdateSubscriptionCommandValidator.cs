namespace SeahawkSaverBackend.Application.Features.Subscription.Commands.Update.Validators;
using FluentValidation;

/**
 * <summary>
 * A validator for the <see cref="UpdateSubscriptionCommand"/>.
 * </summary>
 */
public sealed class UpdateSubscriptionCommandValidator : AbstractValidator<UpdateSubscriptionCommand>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateSubscriptionCommandValidator"/> instance.
	 * </summary>
	 */
	public UpdateSubscriptionCommandValidator()
	{
		RuleFor(command => command.Subscription)
			.SetValidator(new UpdateSubscriptionCommandSubscriptionRequestValidator());
	}
}