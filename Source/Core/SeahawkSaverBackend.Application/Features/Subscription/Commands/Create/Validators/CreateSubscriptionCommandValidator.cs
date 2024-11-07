namespace SeahawkSaverBackend.Application.Features.Subscription.Commands.Create.Validators;
using FluentValidation;

/**
 * <summary>
 * A validator for the <see cref="CreateSubscriptionCommand"/>.
 * </summary>
 */
public sealed class CreateSubscriptionCommandValidator : AbstractValidator<CreateSubscriptionCommand>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateSubscriptionCommandValidator"/> instance.
	 * </summary>
	 */
	public CreateSubscriptionCommandValidator()
	{
		RuleFor(command => command.Subscription)
			.SetValidator(new CreateSubscriptionCommandSubscriptionRequestValidator());
	}
}