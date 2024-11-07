namespace SeahawkSaverBackend.API.Endpoints.Subscription.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer object containing the data for the <see cref="CreateSubscriptionEndpoint"/>.
 * </summary>
 */
public sealed record CreateSubscriptionEndpointRequest
{
	public required CreateSubscriptionEndpointSubscriptionRequest Subscription { get; init; }
}