namespace SeahawkSaverBackend.Application.Features.Expense.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Expense"/> data provided in the
 * request for the <see cref="CreateExpenseCommand"/>.
 * </summary>
 */
public sealed record CreateExpenseCommandExpenseRequest : ExpenseCommandRequest
{
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}