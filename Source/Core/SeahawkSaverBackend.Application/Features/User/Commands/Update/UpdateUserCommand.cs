namespace SeahawkSaverBackend.Application.Features.User.Commands.Update;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.User.Commands.Update.DTOs;

/**
 * <summary>
 * A command for updating an existing <see cref="SeahawkSaverBackend.Domain.Entities.User"/> entity.
 * </summary>
 */
public sealed class UpdateUserCommand : Command<Unit>
{
	public required UpdateUserCommandUserRequest User { get; init; }
}