namespace SeahawkSaverBackend.Application.Features.Subscription.Commands.Update;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.Subscription.Commands.Update.DTOs;

/**
 * <summary>
 * A command for updating an existing <see cref="SeahawkSaverBackend.Domain.Entities.Subscription"/> entity.
 * </summary>
 */
public sealed class UpdateSubscriptionCommand : Command<Unit>
{
	public required UpdateSubscriptionCommandSubscriptionRequest Subscription { get; init; }
}