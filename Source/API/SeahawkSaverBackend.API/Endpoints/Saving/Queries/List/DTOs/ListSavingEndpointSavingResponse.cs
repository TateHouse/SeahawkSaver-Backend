namespace SeahawkSaverBackend.API.Endpoints.Saving.Queries.List.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Saving"/> data provided in the
 * response for the <see cref="ListSavingEndpoint"/>.
 * </summary>
 */
public sealed record ListSavingEndpointSavingResponse
{
	public required Guid SavingId { get; init; }
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}