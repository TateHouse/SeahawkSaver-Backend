namespace SeahawkSaverBackend.Application.Features.Income.Queries.List;
using SeahawkSaverBackend.Application.Abstractions.Application.Queries;
using SeahawkSaverBackend.Application.Features.Income.Queries.List.DTOs;

/**
 * <summary>
 * A query for retrieving all <see cref="SeahawkSaverBackend.Domain.Entities.Income"/> entities from the database with
 * a subset of properties for a specific <see cref="SeahawkSaverBackend.Domain.Entities.User"/>.
 * </summary>
 */
public sealed class ListIncomeQuery : Query<ListIncomeQueryResponse>
{
	public required Guid UserId { get; init; }
}