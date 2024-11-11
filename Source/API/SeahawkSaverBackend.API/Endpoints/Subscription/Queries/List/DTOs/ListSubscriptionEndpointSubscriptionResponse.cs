namespace SeahawkSaverBackend.API.Endpoints.Subscription.Queries.List.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Subscription"/> data provided in
 * the response for the <see cref="ListSubscriptionEndpoint"/>.
 * </summary>
 */
public sealed record ListSubscriptionEndpointSubscriptionResponse
{
	public required Guid SubscriptionId { get; init; }
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}