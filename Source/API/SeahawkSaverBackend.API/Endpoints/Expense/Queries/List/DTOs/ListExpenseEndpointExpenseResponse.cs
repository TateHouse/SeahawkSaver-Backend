namespace SeahawkSaverBackend.API.Endpoints.Expense.Queries.List.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Expense"/> data provided in the
 * response for the <see cref="ListExpenseEndpoint"/>.
 * </summary>
 */
public class ListExpenseEndpointExpenseResponse
{
	public required Guid ExpenseId { get; init; }
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}