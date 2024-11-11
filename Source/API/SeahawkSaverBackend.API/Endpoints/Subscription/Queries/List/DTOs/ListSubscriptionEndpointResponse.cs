namespace SeahawkSaverBackend.API.Endpoints.Subscription.Queries.List.DTOs;
/**
 * <summary>
 * A data transfer object containing the data returned by the <see cref="ListSubscriptionEndpoint"/>.
 * </summary>
 */
public sealed record ListSubscriptionEndpointResponse
{
	public required IReadOnlyList<ListSubscriptionEndpointSubscriptionResponse> Subscriptions { get; init; }
}