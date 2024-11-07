namespace SeahawkSaverBackend.Application.Features.Saving.Commands.Update;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.Saving.Commands.Update.DTOs;

/**
 * <summary>
 * A command for updating an existing <see cref="SeahawkSaverBackend.Domain.Entities.Saving"/> entity.
 * </summary>
 */
public sealed class UpdateSavingCommand : Command<Unit>
{
	public required UpdateSavingCommandSavingRequest Saving { get; init; }
}