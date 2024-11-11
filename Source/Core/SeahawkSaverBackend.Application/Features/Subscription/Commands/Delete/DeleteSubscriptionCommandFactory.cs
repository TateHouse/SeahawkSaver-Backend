namespace SeahawkSaverBackend.Application.Features.Subscription.Commands.Delete;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;

/**
 * <summary>
 * A factory for the <see cref="DeleteSubscriptionCommand"/>.
 * </summary>
 */
public static class DeleteSubscriptionCommandFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="DeleteSubscriptionCommand"/> instance.
	 * </summary>
	 * <param name="commandSettings">The command settings.</param>
	 * <param name="subscriptionId">The id of the subscription to delete.</param>
	 * <param name="userId">The id of the associate user.</param>
	 * <returns>A new <see cref="DeleteSubscriptionCommand"/> isntance.</returns>
	 */
	public static DeleteSubscriptionCommand Create(CommandSettings commandSettings, Guid subscriptionId, Guid userId)
	{
		return new DeleteSubscriptionCommand
		{
			CommandSettings = commandSettings,
			SubscriptionId = subscriptionId,
			UserId = userId
		};
	}
}