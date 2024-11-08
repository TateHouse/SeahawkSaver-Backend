namespace SeahawkSaverBackend.Application.Features.Saving.Commands.Update.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Saving"/> data provided in the
 * request for the <see cref="UpdateSavingCommand"/>.
 * </summary>
 */
public sealed record UpdateSavingCommandSavingRequest : SavingCommandRequest
{
	public required Guid UserId { get; init; }
	public required Guid SavingId { get; init; }
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}