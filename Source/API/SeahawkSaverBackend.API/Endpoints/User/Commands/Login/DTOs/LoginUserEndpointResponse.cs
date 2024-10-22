namespace SeahawkSaverBackend.API.Endpoints.User.Commands.Login.DTOs;
/**
 * <summary>
 * A data transfer object containing the data returned by the <see cref="LoginUserEndpoint"/>.
 * </summary>
 */
public class LoginUserEndpointResponse
{
	public required string Token { get; init; }
	public required LoginUserEndpointUserResponse User { get; init; }
}