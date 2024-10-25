namespace SeahawkSaverBackend.Application.Features.User.Commands.Password.PerformReset;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.User.Commands.Password.PerformReset.DTOs;

/**
 * <summary>
 * A command for a user to perform resetting his password.
 * </summary>
 */
public sealed class PasswordUserPerformResetCommand : Command<Unit>
{
	public required PasswordUserPerformResetCommandRequest Data { get; init; }
}