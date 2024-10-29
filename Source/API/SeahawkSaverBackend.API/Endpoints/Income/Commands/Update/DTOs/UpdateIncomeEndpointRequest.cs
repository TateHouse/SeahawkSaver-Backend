namespace SeahawkSaverBackend.API.Endpoints.Income.Commands.Update.DTOs;
/**
 * <summary>
 * A data transfer object containing the data for the <see cref="UpdateIncomeEndpoint"/>.
 * </summary>
 */
public sealed record UpdateIncomeEndpointRequest
{
	public required UpdateIncomeEndpointIncomeRequest Income { get; init; }
}