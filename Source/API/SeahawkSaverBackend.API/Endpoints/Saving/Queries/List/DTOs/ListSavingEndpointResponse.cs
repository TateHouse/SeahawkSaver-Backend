namespace SeahawkSaverBackend.API.Endpoints.Saving.Queries.List.DTOs;
/**
 * <summary>
 * A data transfer object containing the data returned by the <see cref="ListSavingEndpoint"/>.
 * </summary>
 */
public sealed record ListSavingEndpointResponse
{
	public required IReadOnlyList<ListSavingEndpointSavingResponse> Savings { get; init; }
}