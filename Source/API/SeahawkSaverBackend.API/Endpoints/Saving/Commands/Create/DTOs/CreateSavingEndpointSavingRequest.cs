namespace SeahawkSaverBackend.API.Endpoints.Saving.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Saving"/> data provided in the
 * request for the <see cref="CreateSavingEndpoint"/>.
 * </summary>
 */
public sealed record CreateSavingEndpointSavingRequest
{
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}