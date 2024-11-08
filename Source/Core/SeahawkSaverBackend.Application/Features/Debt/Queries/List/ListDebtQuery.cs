namespace SeahawkSaverBackend.Application.Features.Debt.Queries.List;
using SeahawkSaverBackend.Application.Abstractions.Application.Queries;
using SeahawkSaverBackend.Application.Features.Debt.Queries.List.DTOs;

/**
 * <summary>
 * A query for retrieving all <see cref="SeahawkSaverBackend.Domain.Entities.Debt"/> entities from the database with
 * a subset of properties for a specific <see cref="SeahawkSaverBackend.Domain.Entities.User"/>.
 * </summary>
 */
public sealed class ListDebtQuery : Query<ListDebtQueryResponse>
{
	public required Guid UserId { get; init; }
}