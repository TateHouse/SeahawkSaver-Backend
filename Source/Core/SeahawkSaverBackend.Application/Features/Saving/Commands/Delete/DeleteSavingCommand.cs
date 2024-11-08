namespace SeahawkSaverBackend.Application.Features.Saving.Commands.Delete;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;

/**
 * <summary>
 * A command for deleting a <see cref="SeahawkSaverBackend.Domain.Entities.Saving"/> entity.
 * </summary>
 */
public sealed class DeleteSavingCommand : Command<Unit>
{
	public required Guid SavingId { get; init; }
	public required Guid UserId { get; init; }
}