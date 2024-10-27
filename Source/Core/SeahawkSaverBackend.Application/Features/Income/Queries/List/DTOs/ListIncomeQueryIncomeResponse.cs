namespace SeahawkSaverBackend.Application.Features.Income.Queries.List.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Income"/> data provided in the
 * response for the <see cref="ListIncomeQuery"/>.
 * </summary>
 */
public sealed record ListIncomeQueryIncomeResponse
{
	public required Guid IncomeId { get; init; }
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}