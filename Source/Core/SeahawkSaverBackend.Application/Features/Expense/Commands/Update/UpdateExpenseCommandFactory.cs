namespace SeahawkSaverBackend.Application.Features.Expense.Commands.Update;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.Expense.Commands.Update.DTOs;

/**
 * <summary>
 * A factory for the <see cref="UpdateExpenseCommand"/>.
 * </summary>
 */
public static class UpdateExpenseCommandFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateExpenseCommand"/> instance.
	 * </summary>
	 * <param name="commandSettings">The command settings.</param>
	 * <param name="userId">The id of the associated user.</param>
	 * <param name="expenseId">The expense's id.</param>
	 * <param name="amount">The amount of expense.</param>
	 * <param name="dateTime">The date and time the expense was received.</param>
	 * <returns>A new <see cref="UpdateExpenseCommand"/> instance.</returns>
	 */
	public static UpdateExpenseCommand Create(CommandSettings commandSettings,
											  Guid userId,
											  Guid expenseId,
											  decimal amount,
											  DateTime dateTime)
	{
		return new UpdateExpenseCommand
		{
			CommandSettings = commandSettings,
			Expense = new UpdateExpenseCommandExpenseRequest
			{
				UserId = userId,
				ExpenseId = expenseId,
				Amount = amount,
				DateTime = dateTime
			}
		};
	}
}