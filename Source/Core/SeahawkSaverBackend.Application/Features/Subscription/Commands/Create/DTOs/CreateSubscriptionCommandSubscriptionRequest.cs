namespace SeahawkSaverBackend.Application.Features.Subscription.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Subscription"/> data provided in the
 * request for the <see cref="CreateSubscriptionCommand"/>.
 * </summary>
 */
public sealed record CreateSubscriptionCommandSubscriptionRequest : SubscriptionCommandRequest
{
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}