namespace SeahawkSaverBackend.Domain.Factories;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * A factory for the <see cref="Expense"/> entity.
 * </summary>
 */
public static class ExpenseFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="Expense"/> instance.
	 * </summary>
	 * <param name="expenseId">The expense's id.</param>
	 * <param name="amount">The expense's amount.</param>
	 * <param name="dateTime">The expense's date and time.</param>
	 * <param name="userId">The expense's associated user id.</param>
	 * <returns>A new <see cref="Expense"/> instance.</returns>
	 */
	public static Expense Create(Guid expenseId,
								 decimal amount,
								 DateTime dateTime,
								 Guid userId)
	{
		return new Expense
		{
			ExpenseId = expenseId,
			Amount = amount,
			DateTime = dateTime,
			UserId = userId
		};
	}
}