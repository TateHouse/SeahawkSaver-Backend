namespace SeahawkSaverBackend.Application.Features.User.Commands.Password.PerformReset;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;

/**
 * <summary>
 * A command for a user to perform resetting his password.
 * </summary>
 */
public sealed class PasswordUserPerformResetCommand : Command<Unit>
{
	public required string Token { get; init; }
	public required string Password { get; init; }
}