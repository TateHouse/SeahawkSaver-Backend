namespace SeahawkSaverBackend.Application.Features.Debt.Queries.List.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Debt"/> data provided in the
 * response for the <see cref="ListDebtQuery"/>.
 * </summary>
 */
public sealed record ListDebtQueryDebtResponse
{
	public required Guid DebtId { get; init; }
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}