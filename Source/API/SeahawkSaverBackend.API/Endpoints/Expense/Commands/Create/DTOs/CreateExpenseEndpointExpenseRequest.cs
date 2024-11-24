namespace SeahawkSaverBackend.API.Endpoints.Expense.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Expense"/> data provided in the
 * request for the <see cref="CreateExpenseEndpoint"/>.
 * </summary>
 */
public sealed record CreateExpenseEndpointExpenseRequest
{
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}