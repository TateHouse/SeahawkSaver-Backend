namespace SeahawkSaverBackend.Application.Features.Expense.Commands.Update.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Expense"/> data provided in the
 * request for the <see cref="UpdateExpenseCommand"/>.
 * </summary>
 */
public sealed record UpdateExpenseCommandExpenseRequest : ExpenseCommandRequest
{
	public required Guid UserId { get; init; }
	public required Guid ExpenseId { get; init; }
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}