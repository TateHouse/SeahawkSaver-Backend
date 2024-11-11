namespace SeahawkSaverBackend.Application.Features.Subscription.Commands.Update.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Subscription"/> data provided in
 * the request for the <see cref="UpdateSubscriptionCommand"/>.
 * </summary>
 */
public sealed record UpdateSubscriptionCommandSubscriptionRequest : SubscriptionCommandRequest
{
	public required Guid UserId { get; init; }
	public required Guid SubscriptionId { get; init; }
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}