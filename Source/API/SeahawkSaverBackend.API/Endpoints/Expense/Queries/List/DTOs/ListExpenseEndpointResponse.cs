namespace SeahawkSaverBackend.API.Endpoints.Expense.Queries.List.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Expense"/> data provided in the
 * response for the <see cref="ListExpenseEndpoint"/>.
 * </summary>
 */
public sealed record ListExpenseEndpointResponse
{
	public required IReadOnlyList<ListExpenseEndpointExpenseResponse> Expenses { get; init; }
}