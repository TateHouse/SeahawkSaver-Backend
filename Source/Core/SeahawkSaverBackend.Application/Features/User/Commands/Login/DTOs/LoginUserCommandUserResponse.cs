namespace SeahawkSaverBackend.Application.Features.User.Commands.Login.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.User"/> data provided in the
 * response for the <see cref="LoginUserCommand"/>.
 * </summary>
 */
public class LoginUserCommandUserResponse
{
	public required Guid UserId { get; init; }
	public required string Email { get; init; }
}