namespace SeahawkSaverBackend.API.Endpoints.User.Commands.Password.PerformReset.DTOs;
/**
 * <summary>
 * A data transfer object containing the data for the <see cref="PasswordUserPerformResetEndpoint"/>.
 * </summary>
 */
public class PasswordUserPerformResetEndpointRequest
{
	public required string Token { get; init; }
	public required string Password { get; init; }
}