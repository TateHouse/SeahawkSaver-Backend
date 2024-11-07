namespace SeahawkSaverBackend.Application.Features.Subscription.Commands.Create;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.Subscription.Commands.Create.DTOs;

/**
 * <summary>
 * A factory for the <see cref="CreateSubscriptionCommand"/>.
 * </summary>
 */
public static class CreateSubscriptionCommandFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateSubscriptionCommand"/> instance.
	 * </summary>
	 * <param name="commandSettings">The command settings.</param>
	 * <param name="userId">The id of the associated user.</param>
	 * <param name="amount">The amount of subscription.</param>
	 * <param name="dateTime">The date and time the subscription was received.</param>
	 * <returns>A new <see cref="CreateSubscriptionCommand"/> instance.</returns>
	 */
	public static CreateSubscriptionCommand Create(CommandSettings commandSettings,
											 Guid userId,
											 decimal amount,
											 DateTime dateTime)
	{
		return new CreateSubscriptionCommand
		{
			CommandSettings = commandSettings,
			UserId = userId,
			Subscription = new CreateSubscriptionCommandSubscriptionRequest
			{
				Amount = amount,
				DateTime = dateTime
			}
		};
	}
}