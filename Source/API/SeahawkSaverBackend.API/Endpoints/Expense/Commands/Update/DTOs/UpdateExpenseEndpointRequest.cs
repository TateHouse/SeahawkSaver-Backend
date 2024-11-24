namespace SeahawkSaverBackend.API.Endpoints.Expense.Commands.Update.DTOs;
/**
 * <summary>
 * A data transfer object containing the data for the <see cref="UpdateExpenseEndpoint"/>.
 * </summary>
 */
public sealed record UpdateExpenseEndpointRequest
{
	public required UpdateExpenseEndpointExpenseRequest Expense { get; init; }
}