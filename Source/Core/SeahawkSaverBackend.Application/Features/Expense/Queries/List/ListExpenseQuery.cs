namespace SeahawkSaverBackend.Application.Features.Expense.Queries.List;
using SeahawkSaverBackend.Application.Abstractions.Application.Queries;
using SeahawkSaverBackend.Application.Features.Expense.Queries.List.DTOs;

/**
 * <summary>
 * A query for retrieving all <see cref="SeahawkSaverBackend.Domain.Entities.Expense"/> entities from the database with
 * a subset of properties for a specific <see cref="SeahawkSaverBackend.Domain.Entities.User"/>.
 * </summary>
 */
public sealed class ListExpenseQuery : Query<ListExpenseQueryResponse>
{
	public required Guid UserId { get; init; }
}