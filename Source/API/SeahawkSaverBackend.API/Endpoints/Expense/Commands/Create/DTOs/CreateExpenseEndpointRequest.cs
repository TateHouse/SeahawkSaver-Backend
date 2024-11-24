namespace SeahawkSaverBackend.API.Endpoints.Expense.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer object containing the data for the <see cref="CreateExpenseEndpoint"/>.
 * </summary>
 */
public sealed record CreateExpenseEndpointRequest
{
	public required CreateExpenseEndpointExpenseRequest Expense { get; init; }
}