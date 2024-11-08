namespace SeahawkSaverBackend.API.Endpoints.Debt.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer object containing the data for the <see cref="CreateDebtEndpoint"/>.
 * </summary>
 */
public sealed record CreateDebtEndpointRequest
{
	public required CreateDebtEndpointDebtRequest Debt { get; init; }
}