namespace SeahawkSaverBackend.Application.Features.Subscription.Commands.Create;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.Subscription.Commands.Create.DTOs;
/**
 * <summary>
 * A command for creating a new <see cref="SeahawkSaverBackend.Domain.Entities.Subscription"/> entity.
 * </summary>
 */
public sealed class CreateSubscriptionCommand : Command<CreateSubscriptionCommandResponse>
{
	public required Guid UserId { get; init; }
	public required CreateSubscriptionCommandSubscriptionRequest Subscription { get; init; }
}