namespace SeahawkSaverBackend.Application.Features.Expense.Commands.Create;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.Expense.Commands.Create.DTOs;

/**
 * <summary>
 * A factory for the <see cref="CreateExpenseCommand"/>.
 * </summary>
 */
public static class CreateExpenseCommandFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateExpenseCommand"/> instance.
	 * </summary>
	 * <param name="commandSettings">The command settings.</param>
	 * <param name="userId">The id of the associated user.</param>
	 * <param name="amount">The amount of expense.</param>
	 * <param name="dateTime">The date and time the expense was received.</param>
	 * <returns>A new <see cref="CreateExpenseCommand"/> instance.</returns>
	 */
	public static CreateExpenseCommand Create(CommandSettings commandSettings,
											  Guid userId,
											  decimal amount,
											  DateTime dateTime)
	{
		return new CreateExpenseCommand
		{
			CommandSettings = commandSettings,
			UserId = userId,
			Expense = new CreateExpenseCommandExpenseRequest
			{
				Amount = amount,
				DateTime = dateTime
			}
		};
	}
}