namespace SeahawkSaverBackend.API.Endpoints.User.Commands.Update.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.User"/> data provided in the
 * request for the <see cref="UpdateUserEndpoint"/>.
 * </summary>
 */
public sealed record UpdateUserEndpointUserRequest
{
	public required string Email { get; init; }
	public required string FirstName { get; init; }
	public required string LastName { get; init; }
}