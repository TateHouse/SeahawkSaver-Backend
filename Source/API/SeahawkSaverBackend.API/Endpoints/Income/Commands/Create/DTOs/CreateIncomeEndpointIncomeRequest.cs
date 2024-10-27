namespace SeahawkSaverBackend.API.Endpoints.Income.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Income"/> data provided in the
 * request for the <see cref="CreateIncomeEndpoint"/>.
 * </summary>
 */
public sealed record CreateIncomeEndpointIncomeRequest
{
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}