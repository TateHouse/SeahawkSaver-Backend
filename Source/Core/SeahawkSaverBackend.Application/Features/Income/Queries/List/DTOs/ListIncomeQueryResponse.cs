namespace SeahawkSaverBackend.Application.Features.Income.Queries.List.DTOs;
/**
 * <summary>
 * A data transfer object containing the data returned by the <see cref="ListIncomeQuery"/>.
 * </summary>
 */
public sealed record ListIncomeQueryResponse
{
	public required IReadOnlyList<ListIncomeQueryIncomeResponse> Incomes { get; init; }
}