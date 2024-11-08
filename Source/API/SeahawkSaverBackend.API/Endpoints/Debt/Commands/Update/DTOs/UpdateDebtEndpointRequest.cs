namespace SeahawkSaverBackend.API.Endpoints.Debt.Commands.Update.DTOs;
/**
 * <summary>
 * A data transfer object containing the data for the <see cref="UpdateDebtEndpoint"/>.
 * </summary>
 */
public sealed record UpdateDebtEndpointRequest
{
	public required UpdateDebtEndpointDebtRequest Debt { get; init; }
}