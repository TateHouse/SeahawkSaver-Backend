namespace SeahawkSaverBackend.API.Endpoints.Debt.Queries.List.DTOs;

/**
 * <summary>
 * A data transfer object containing the data returned by the <see cref="ListDebtEndpoint"/>.
 * </summary>
 */
public sealed record ListDebtEndpointResponse
{
	public required IReadOnlyList<ListDebtEndpointDebtResponse> Debts { get; init; }
}