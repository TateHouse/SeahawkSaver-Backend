namespace SeahawkSaverBackend.API.Endpoints.Saving.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer object containing the data for the <see cref="CreateSavingEndpoint"/>.
 * </summary>
 */
public sealed record CreateSavingEndpointRequest
{
	public required CreateSavingEndpointSavingRequest Saving { get; init; }
}