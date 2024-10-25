namespace SeahawkSaverBackend.Application.Features.User.Commands.Password.RequestReset;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;

/**
 * <summary>
 * A command for a user to reset his password.
 * </summary>
 */
public sealed class PasswordUserRequestResetCommand : Command<Unit>
{
	public required string Email { get; init; }
}