namespace SeahawkSaverBackend.Application.Features.Subscription.Queries.List;
using SeahawkSaverBackend.Application.Abstractions.Application.Queries;
using SeahawkSaverBackend.Application.Features.Subscription.Queries.List.DTOs;

/**
 * <summary>
 * A query for retrieving all <see cref="SeahawkSaverBackend.Domain.Entities.Subscription"/> entities from the database
 * with a subset of properties for a specific <see cref="SeahawkSaverBackend.Domain.Entities.User"/>.
 * </summary>
 */
public sealed class ListSubscriptionQuery : Query<ListSubscriptionQueryResponse>
{
	public required Guid UserId { get; init; }
}