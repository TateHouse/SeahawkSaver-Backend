namespace SeahawkSaverBackend.Application.Features.Subscription.Commands.Delete;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;

/**
 * <summary>
 * A command for deleting a <see cref="SeahawkSaverBackend.Domain.Entities.Subscription"/> entity.
 * </summary>
 */
public sealed class DeleteSubscriptionCommand : Command<Unit>
{
	public required Guid SubscriptionId { get; init; }
	public required Guid UserId { get; init; }
}