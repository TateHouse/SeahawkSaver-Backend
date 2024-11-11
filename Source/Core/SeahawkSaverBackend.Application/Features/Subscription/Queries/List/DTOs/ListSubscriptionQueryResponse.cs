namespace SeahawkSaverBackend.Application.Features.Subscription.Queries.List.DTOs;
/**
 * <summary>
 * A data transfer object containing the data returned by the <see cref="ListSubscriptionQuery"/>.
 * </summary>
 */
public sealed record ListSubscriptionQueryResponse
{
	public required IReadOnlyList<ListSubscriptionQueryResponse> Subscriptions { get; init; }
}