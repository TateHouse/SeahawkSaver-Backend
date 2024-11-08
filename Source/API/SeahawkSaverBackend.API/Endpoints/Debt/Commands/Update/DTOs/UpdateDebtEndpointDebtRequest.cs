namespace SeahawkSaverBackend.API.Endpoints.Debt.Commands.Update.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Debt"/> data provided in the
 * request for the <see cref="UpdateDebtEndpoint"/>.
 * </summary>
 */
public sealed record UpdateDebtEndpointDebtRequest
{
	public required Guid DebtId { get; init; }
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}