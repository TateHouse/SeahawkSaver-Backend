namespace SeahawkSaverBackend.Application.Features.Subscription.Commands.Create.DTOs;
/**
 * <summary>
 * A data transfer containing the data returned by the <see cref="CreateSubscriptionCommand"/>.
 * </summary>
 */
public sealed record CreateSubscriptionCommandResponse
{
	public required Guid SubscriptionId { get; init; }
}