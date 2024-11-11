namespace SeahawkSaverBackend.API.Endpoints.Subscription.Commands.Update.DTOs;
/**
 * <summary>
 * A data transfer object containing the data for the <see cref="UpdateSubscriptionEndpoint"/>.
 * </summary>
 */
public sealed record UpdateSubscriptionEndpointRequest
{
	public required UpdateSubscriptionEndpointSubscriptionRequest Subscription { get; init; }
}