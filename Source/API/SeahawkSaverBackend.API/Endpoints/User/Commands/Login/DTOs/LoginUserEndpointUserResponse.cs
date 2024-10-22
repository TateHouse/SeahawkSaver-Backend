namespace SeahawkSaverBackend.API.Endpoints.User.Commands.Login.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.User"/> data provided in the
 * response for the <see cref="LoginUserEndpoint"/>.
 * </summary>
 */
public class LoginUserEndpointUserResponse
{
	public required Guid UserId { get; init; }
	public required string Email { get; init; }
}