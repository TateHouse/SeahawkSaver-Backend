namespace SeahawkSaverBackend.Application.Features.Subscription.Commands.Update;
using AutoMapper;
using FluentValidation;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Subscription.Queries.Specifications;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The command handler for the <see cref="UpdateSubscriptionCommand"/>.
 * </summary>
 */
public sealed class UpdateSubscriptionCommandHandler : CommandHandler<UpdateSubscriptionCommand, Unit>
{
	private readonly IMapper mapper;

	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateSubscriptionCommandHandler"/> instance.
	 * </summary>
	 * <param name="transaction">The "unit of work" used during the command execution.</param>
	 * <param name="validator">An optional validator for the command. If provided, it will be used to validate the
	 * command before execution. Otherwise, no validation will occur.</param>
	 * <param name="mapper">The AutoMapper to use.</param>
	 */
	public UpdateSubscriptionCommandHandler(ICommandTransaction transaction,
											IValidator<UpdateSubscriptionCommand>? validator,
											IMapper mapper)
		: base(transaction, validator)
	{
		this.mapper = mapper;
	}

	protected override async Task<Unit> HandleAsync(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
	{
		var specification = new GetSubscriptionByIdSpecification(request.Subscription.SubscriptionId, request.Subscription.UserId);
		var subscription = await Transaction.SubscriptionRepository.SingleOrDefaultAsync(specification, cancellationToken);

		if (subscription == null)
		{
			throw new NotFoundException(nameof(Subscription), request.Subscription.SubscriptionId);
		}

		mapper.Map(request.Subscription, subscription);

		await Transaction.SubscriptionRepository.UpdateAsync(subscription, cancellationToken);

		return Unit.Value;
	}
}