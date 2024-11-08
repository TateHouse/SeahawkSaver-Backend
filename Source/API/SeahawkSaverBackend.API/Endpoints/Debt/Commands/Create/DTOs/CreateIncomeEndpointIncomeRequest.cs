namespace SeahawkSaverBackend.API.Endpoints.Debt.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Debt"/> data provided in the
 * request for the <see cref="CreateDebtEndpoint"/>.
 * </summary>
 */
public sealed record CreateDebtEndpointDebtRequest
{
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}