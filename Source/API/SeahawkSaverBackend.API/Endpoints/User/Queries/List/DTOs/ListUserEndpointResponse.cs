namespace SeahawkSaverBackend.API.Endpoints.User.Queries.List.DTOs;
/**
 * <summary>
 * A data transfer object containing the data returned by the <see cref="ListUserEndpoint"/>.
 * </summary>
 */
public sealed record ListUserEndpointResponse
{
	public required IReadOnlyList<ListUserEndpointUserResponse> Users { get; init; }
}