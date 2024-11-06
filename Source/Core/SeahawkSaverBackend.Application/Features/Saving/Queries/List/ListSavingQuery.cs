namespace SeahawkSaverBackend.Application.Features.Saving.Queries.List;
using SeahawkSaverBackend.Application.Abstractions.Application.Queries;
using SeahawkSaverBackend.Application.Features.Saving.Queries.List.DTOs;

/**
 * <summary>
 * A query for retrieving all <see cref="SeahawkSaverBackend.Domain.Entities.Saving"/> entities from the database with
 * a subset of properties for a specific <see cref="SeahawkSaverBackend.Domain.Entities.User"/>.
 * </summary>
 */
public sealed class ListSavingQuery : Query<ListSavingQueryResponse>
{
	public required Guid UserId { get; init; }
}