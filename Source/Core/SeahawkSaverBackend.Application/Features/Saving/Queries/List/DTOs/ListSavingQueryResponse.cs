namespace SeahawkSaverBackend.Application.Features.Saving.Queries.List.DTOs;
/**
 * <summary>
 * A data transfer object containing the data returned by the <see cref="ListSavingQuery"/>.
 * </summary>
 */
public sealed record ListSavingQueryResponse
{
	public required IReadOnlyList<ListSavingQuerySavingResponse> Savings { get; init; }
}