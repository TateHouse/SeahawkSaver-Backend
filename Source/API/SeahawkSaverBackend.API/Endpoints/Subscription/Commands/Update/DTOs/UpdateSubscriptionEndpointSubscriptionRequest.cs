namespace SeahawkSaverBackend.API.Endpoints.Subscription.Commands.Update.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Subscription"/> data provided in
 * the request for the <see cref="UpdateSubscriptionEndpoint"/>.
 * </summary>
 */
public sealed record UpdateSubscriptionEndpointSubscriptionRequest
{
	public required Guid SubscriptionId { get; init; }
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}