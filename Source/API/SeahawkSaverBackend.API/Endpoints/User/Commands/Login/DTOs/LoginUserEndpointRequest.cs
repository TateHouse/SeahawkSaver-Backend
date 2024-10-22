namespace SeahawkSaverBackend.API.Endpoints.User.Commands.Login.DTOs;
/**
 * <summary>
 * A data transfer object containing the data for the <see cref="LoginUserEndpoint"/>.
 * </summary>
 */
public sealed record LoginUserEndpointRequest
{
	public required string Email { get; init; }
	public required string Password { get; init; }
}