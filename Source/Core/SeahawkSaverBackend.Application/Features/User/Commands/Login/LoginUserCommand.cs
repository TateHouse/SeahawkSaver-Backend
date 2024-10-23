namespace SeahawkSaverBackend.Application.Features.User.Commands.Login;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.User.Commands.Login.DTOs;

/**
 * <summary>
 * A command for a user to login.
 * </summary>
 */
public sealed class LoginUserCommand : Command<LoginUserCommandResponse>
{
	public required string Email { get; init; }
	public required string Password { get; init; }
}