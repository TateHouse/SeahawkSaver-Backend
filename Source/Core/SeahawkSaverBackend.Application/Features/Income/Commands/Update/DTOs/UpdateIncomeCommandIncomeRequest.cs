namespace SeahawkSaverBackend.Application.Features.Income.Commands.Update.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Income"/> data provided in the
 * request for the <see cref="UpdateIncomeCommand"/>.
 * </summary>
 */
public sealed record UpdateIncomeCommandIncomeRequest : IncomeCommandRequest
{
	public required Guid UserId { get; init; }
	public required Guid IncomeId { get; init; }
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}