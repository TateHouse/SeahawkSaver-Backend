namespace SeahawkSaverBackend.API.Endpoints.User.Commands.Password.RequestReset.DTOs;
/**
 * <summary>
 * A data transfer object containing the data for the <see cref="PasswordUserRequestResetEndpoint"/>.
 * </summary>
 */
public class PasswordUserRequestResetEndpointRequest
{
	public required string Email { get; init; }
}