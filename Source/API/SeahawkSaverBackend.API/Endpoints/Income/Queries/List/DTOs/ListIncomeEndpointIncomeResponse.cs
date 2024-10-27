namespace SeahawkSaverBackend.API.Endpoints.Income.Queries.List.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Income"/> data provided in the
 * response for the <see cref="ListIncomeEndpoint"/>.
 * </summary>
 */
public sealed record ListIncomeEndpointIncomeResponse
{
	public required Guid IncomeId { get; init; }
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}