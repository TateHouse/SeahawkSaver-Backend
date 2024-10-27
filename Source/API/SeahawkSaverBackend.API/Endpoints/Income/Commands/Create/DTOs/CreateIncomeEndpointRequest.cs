namespace SeahawkSaverBackend.API.Endpoints.Income.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer object containing the data for the <see cref="CreateIncomeEndpoint"/>.
 * </summary>
 */
public sealed record CreateIncomeEndpointRequest
{
	public required CreateIncomeEndpointIncomeRequest Income { get; init; }
}