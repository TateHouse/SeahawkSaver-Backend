namespace SeahawkSaverBackend.Application.Features.Expense.Queries.List.DTOs;
/**
 * <summary>
 * A data transfer object containing the data returned by the <see cref="ListExpenseQuery"/>.
 * </summary>
 */
public class ListExpenseQueryResponse
{
	public required IReadOnlyList<ListExpenseQueryExpenseResponse> Expenses { get; init; }
}