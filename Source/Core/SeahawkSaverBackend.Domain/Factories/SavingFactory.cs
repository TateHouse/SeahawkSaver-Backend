namespace SeahawkSaverBackend.Domain.Factories;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * A factory for the <see cref="Saving"/> entity.
 * </summary>
 */
public static class SavingFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="Saving"/> instance.
	 * </summary>
	 * <param name="savingId">The saving's id.</param>
	 * <param name="amount">The saving's amount.</param>
	 * <param name="dateTime">The saving's date and time.</param>
	 * <param name="userId">The saving's associated user id.</param>
	 * <returns>A new <see cref="Saving"/> instance.</returns>
	 */
	public static Saving Create(Guid savingId,
								decimal amount,
								DateTime dateTime,
								Guid userId)
	{
		return new Saving
		{
			SavingId = savingId,
			Amount = amount,
			DateTime = dateTime,
			UserId = userId
		};
	}
}