namespace SeahawkSaverBackend.API.Endpoints.Subscription.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Subscription"/> data provided in the
 * request for the <see cref="CreateSubscriptionEndpoint"/>.
 * </summary>
 */
public sealed record CreateSubscriptionEndpointSubscriptionRequest
{
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}