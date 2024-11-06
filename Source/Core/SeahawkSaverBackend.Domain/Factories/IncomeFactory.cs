namespace SeahawkSaverBackend.Domain.Factories;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * A factory for the <see cref="Income"/> entity.
 * </summary>
 */
public static class IncomeFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="Income"/> instance.
	 * </summary>
	 * <param name="incomeId">The income's id.</param>
	 * <param name="amount">The income's amount.</param>
	 * <param name="dateTime">The income's date and time.</param>
	 * <param name="userId">The income's associated user id.</param>
	 * <returns>A new <see cref="Income"/> instance.</returns>
	 */
	public static Income Create(Guid incomeId,
								decimal amount,
								DateTime dateTime,
								Guid userId)
	{
		return new Income
		{
			IncomeId = incomeId,
			Amount = amount,
			DateTime = dateTime,
			UserId = userId
		};
	}
}