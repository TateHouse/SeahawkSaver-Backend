namespace SeahawkSaverBackend.API.Endpoints.Income.Queries.List.DTOs;

/**
 * <summary>
 * A data transfer object containing the data returned by the <see cref="ListIncomeEndpoint"/>.
 * </summary>
 */
public sealed record ListIncomeEndpointResponse
{
	public required IReadOnlyList<ListIncomeEndpointIncomeResponse> Incomes { get; init; }
}