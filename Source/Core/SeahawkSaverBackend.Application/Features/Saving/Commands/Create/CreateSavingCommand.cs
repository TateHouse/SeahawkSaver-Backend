namespace SeahawkSaverBackend.Application.Features.Saving.Commands.Create;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.Saving.Commands.Create.DTOs;

/**
 * <summary>
 * A command for creating a new <see cref="SeahawkSaverBackend.Domain.Entities.Saving"/> entity.
 * </summary>
 */
public sealed class CreateSavingCommand : Command<CreateSavingCommandResponse>
{
	public required Guid UserId { get; init; }
	public required CreateSavingCommandSavingRequest Saving { get; init; }
}