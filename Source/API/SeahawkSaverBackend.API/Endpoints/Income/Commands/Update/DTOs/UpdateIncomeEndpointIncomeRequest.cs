namespace SeahawkSaverBackend.API.Endpoints.Income.Commands.Update.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Income"/> data provided in the
 * request for the <see cref="UpdateIncomeEndpoint"/>.
 * </summary>
 */
public sealed record UpdateIncomeEndpointIncomeRequest
{
	public required Guid IncomeId { get; init; }
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}