namespace SeahawkSaverBackend.Domain.Factories;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * A factory for the <see cref="Debt"/> entity.
 * </summary>
 */
public static class DebtFactory
{
	/**
	 * <summary>
	 * Instantaites a new <see cref="Debt"/> instance.
	 * </summary>
	 * <param name="debtId">The debt's id.</param>
	 * <param name="amount">The debt's amount.</param>
	 * <param name="dateTime">The debt's date and time.</param>
	 * <param name="userId">The debt's associated user id.</param>
	 * <returns>A new <see cref="Debt"/> instance.</returns>
	 */
	public static Debt Create(Guid debtId,
								decimal amount,
								DateTime dateTime,
								Guid userId)
	{
		return new Debt
		{
			DebtId = debtId,
			Amount = amount,
			DateTime = dateTime,
			UserId = userId
		};
	}
}