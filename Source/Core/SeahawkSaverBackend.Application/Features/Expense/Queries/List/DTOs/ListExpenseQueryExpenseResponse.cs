namespace SeahawkSaverBackend.Application.Features.Expense.Queries.List.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Expense"/> data provided in the
 * response for the <see cref="ListExpenseQuery"/>.
 * </summary>
 */
public sealed record ListExpenseQueryExpenseResponse
{
	public required Guid ExpenseId { get; init; }
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}