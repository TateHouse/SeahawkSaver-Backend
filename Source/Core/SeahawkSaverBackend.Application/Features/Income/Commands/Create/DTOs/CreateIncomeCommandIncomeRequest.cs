namespace SeahawkSaverBackend.Application.Features.Income.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Income"/> data provided in the
 * request for the <see cref="CreateIncomeCommand"/>.
 * </summary>
 */
public sealed record CreateIncomeCommandIncomeRequest : IncomeCommandRequest
{
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}