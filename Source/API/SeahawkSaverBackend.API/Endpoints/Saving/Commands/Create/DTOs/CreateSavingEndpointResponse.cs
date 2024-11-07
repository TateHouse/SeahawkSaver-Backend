namespace SeahawkSaverBackend.API.Endpoints.Saving.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer object containing the data returned by the <see cref="CreateSavingEndpoint"/>.
 * </summary>
 */
public sealed record CreateSavingEndpointResponse
{
	public required Guid SavingId { get; init; }
}