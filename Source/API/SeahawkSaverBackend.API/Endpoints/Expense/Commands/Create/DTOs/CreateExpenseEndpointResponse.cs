namespace SeahawkSaverBackend.API.Endpoints.Expense.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer object containing the data returned by the <see cref="CreateExpenseEndpoint"/>.
 * </summary>
 */
public sealed record CreateExpenseEndpointResponse
{
	public required Guid ExpenseId { get; init; }
}