namespace SeahawkSaverBackend.API.Endpoints.Saving.Commands.Update.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Saving"/> data provided in the
 * request for the <see cref="UpdateSavingEndpoint"/>.
 * </summary>
 */
public sealed record UpdateSavingEndpointSavingRequest
{
	public required Guid SavingId { get; init; }
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}