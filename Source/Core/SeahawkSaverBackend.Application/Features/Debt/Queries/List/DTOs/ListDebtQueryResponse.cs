namespace SeahawkSaverBackend.Application.Features.Debt.Queries.List.DTOs;
/**
 * <summary>
 * A data transfer object containing the data returned by the <see cref="ListDebtQuery"/>.
 * </summary>
 */
public sealed record ListDebtQueryResponse
{
	public required IReadOnlyList<ListDebtQueryDebtResponse> Debts { get; init; }
}