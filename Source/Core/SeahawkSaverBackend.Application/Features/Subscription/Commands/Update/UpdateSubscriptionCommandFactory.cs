namespace SeahawkSaverBackend.Application.Features.Subscription.Commands.Update;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.Subscription.Commands.Update.DTOs;

/**
 * <summary>
 * A factory for the <see cref="UpdateSubscriptionCommand"/>.
 * </summary>
 */
public static class UpdateSubscriptionCommandFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateSubscriptionCommandFactory"/> instance.
	 * </summary>
	 * <param name="commandSettings">The command settings.</param>
	 * <param name="userId">The id of the associated user.</param>
	 * <param name="subscriptionId">The subscription's id.</param>
	 * <param name="amount">The amount of income.</param>
	 * <param name="dateTime">The date and time the income was received.</param>
	 * <returns>A new <see cref="UpdateSubscriptionCommand"/> instance.</returns>
	 */
	public static UpdateSubscriptionCommand Create(CommandSettings commandSettings,
												   Guid userId,
												   Guid subscriptionId,
												   decimal amount,
												   DateTime dateTime)
	{
		return new UpdateSubscriptionCommand
		{
			CommandSettings = commandSettings,
			Subscription = new UpdateSubscriptionCommandSubscriptionRequest
			{
				UserId = userId,
				SubscriptionId = subscriptionId,
				Amount = amount,
				DateTime = dateTime
			}
		};
	}
}