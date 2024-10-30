namespace SeahawkSaverBackend.API.Endpoints.User.Commands.Update.DTOs;
/**
 * <summary>
 * A data tranfer object containing the data for the <see cref="UpdateUserEndpoint"/>.
 * </summary>
 */
public sealed record UpdateUserEndpointRequest
{
	public required UpdateUserEndpointUserRequest User { get; init; }
}