namespace SeahawkSaverBackend.Application.Features.Subscription.Queries.List.DTOs;
/**
 * <summary>
 * A data transfer object containing the <see cref="SeahawkSaverBackend.Domain.Entities.Subscription"/> data provided in
 * the response for the <see cref="ListSubscriptionQuery"/>.
 * </summary>
 */
public sealed record ListSubscriptionQuerySubscriptionResponse
{
	public required Guid SubscriptionId { get; init; }
	public required decimal Amount { get; init; }
	public required DateTime DateTime { get; init; }
}