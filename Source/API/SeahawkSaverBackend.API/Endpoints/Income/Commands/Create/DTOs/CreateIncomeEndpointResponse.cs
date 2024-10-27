namespace SeahawkSaverBackend.API.Endpoints.Income.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer object containing the data returned by the <see cref="CreateIncomeEndpoint"/>.
 * </summary>
 */
public sealed record CreateIncomeEndpointResponse
{
	public required Guid IncomeId { get; init; }
}