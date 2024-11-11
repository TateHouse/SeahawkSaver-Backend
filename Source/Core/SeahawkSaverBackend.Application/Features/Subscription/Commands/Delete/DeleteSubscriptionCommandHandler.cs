namespace SeahawkSaverBackend.Application.Features.Subscription.Commands.Delete;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Subscription.Queries.Specifications;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The command handler for the <see cref="DeleteSubscriptionCommand"/>.
 * </summary>
 */
public sealed class DeleteSubscriptionCommandHandler : CommandHandler<DeleteSubscriptionCommand, Unit>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="DeleteSubscriptionCommandHandler"/> instance.
	 * </summary>
	 * <param name="transaction">The "unit of work" used during the command execution.</param>
	 */
	public DeleteSubscriptionCommandHandler(ICommandTransaction transaction)
		: base(transaction, null)
	{

	}

	protected override async Task<Unit> HandleAsync(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
	{
		var specification = new GetSubscriptionByIdSpecification(request.SubscriptionId, request.UserId);
		var subscription = await Transaction.SubscriptionRepository.SingleOrDefaultAsync(specification, cancellationToken);

		if (subscription == null)
		{
			throw new NotFoundException(nameof(Subscription), request.SubscriptionId);
		}

		await Transaction.SubscriptionRepository.DeleteAsync(subscription, cancellationToken);

		return Unit.Value;
	}
}