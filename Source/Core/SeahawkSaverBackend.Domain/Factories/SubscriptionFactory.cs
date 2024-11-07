namespace SeahawkSaverBackend.Domain.Factories;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * A factory for the <see cref="Subscription"/> entity.
 * </summary>
 */
public static class SubscriptionFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="Subscription"/> instance.
	 * </summary>
	 * <param name="subscriptionId">The saving's id.</param>
	 * <param name="amount">The saving's amount.</param>
	 * <param name="dateTime">The saving's date and time.</param>
	 * <param name="userId">The saving's associated user id.</param>
	 * <returns>A new <see cref="Subscription"/> instance.</returns>
	 */
	public static Subscription Create(Guid subscriptionId,
								decimal amount,
								DateTime dateTime,
								Guid userId)
	{
		return new Subscription
		{
			SubscriptionId = subscriptionId,
			Amount = amount,
			DateTime = dateTime,
			UserId = userId
		};
	}
}