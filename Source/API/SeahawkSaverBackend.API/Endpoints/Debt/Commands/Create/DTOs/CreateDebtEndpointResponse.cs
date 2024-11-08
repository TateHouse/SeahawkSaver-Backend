namespace SeahawkSaverBackend.API.Endpoints.Debt.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer object containing the data returned by the <see cref="CreateDebtEndpoint"/>.
 * </summary>
 */
public sealed record CreateDebtEndpointResponse
{
	public required Guid DebtId { get; init; }
}