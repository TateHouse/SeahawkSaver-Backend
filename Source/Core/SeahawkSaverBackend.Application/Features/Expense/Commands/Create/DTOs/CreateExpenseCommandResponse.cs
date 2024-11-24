namespace SeahawkSaverBackend.Application.Features.Expense.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer containing the data returned by the <see cref="CreateExpenseCommand"/>.
 * </summary>
 */
public sealed record CreateExpenseCommandResponse
{
	public required Guid ExpenseId { get; init; }
}