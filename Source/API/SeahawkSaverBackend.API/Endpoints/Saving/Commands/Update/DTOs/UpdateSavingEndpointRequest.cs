namespace SeahawkSaverBackend.API.Endpoints.Saving.Commands.Update.DTOs;
/**
 * <summary>
 * A data transfer object containing the data for the <see cref="UpdateSavingEndpoint"/>.
 * </summary>
 */
public sealed record UpdateSavingEndpointRequest
{
	public required UpdateSavingEndpointSavingRequest Saving { get; init; }
}