namespace SeahawkSaverBackend.Application.Features.Saving.Commands.Create.DTOs;

/**
 * <summary>
 * A data transfer object containing the data returned by the <see cref="CreateSavingCommand"/>.
 * </summary>
 */
public sealed record CreateSavingCommandResponse
{
	public required Guid SavingId { get;init; }
}