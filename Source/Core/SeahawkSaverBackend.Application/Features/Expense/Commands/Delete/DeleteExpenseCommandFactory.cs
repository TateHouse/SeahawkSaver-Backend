namespace SeahawkSaverBackend.Application.Features.Expense.Commands.Delete;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;

/**
 * <summary>
 * A factory for the <see cref="DeleteExpenseCommand"/>.
 * </summary>
 */
public static class DeleteExpenseCommandFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="DeleteExpenseCommand"/> instance.
	 * </summary>
	 * <param name="commandSettings">The command settings.</param>
	 * <param name="expenseId">The id of the expense to delete.</param>
	 * <param name="userId">The id of the associate user.</param>
	 * <returns>A new <see cref="DeleteExpenseCommand"/> isntance.</returns>
	 */
	public static DeleteExpenseCommand Create(CommandSettings commandSettings, Guid expenseId, Guid userId)
	{
		return new DeleteExpenseCommand
		{
			CommandSettings = commandSettings,
			ExpenseId = expenseId,
			UserId = userId
		};
	}
}