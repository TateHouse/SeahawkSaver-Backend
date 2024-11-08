namespace SeahawkSaverBackend.API.Endpoints.Subscription.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer object containing the data returned by the <see cref="CreateSubscriptionEndpoint"/>.
 * </summary>
 */
public sealed record CreateSubscriptionEndpointResponse
{
	public required Guid SubscriptionId { get; init; }
}