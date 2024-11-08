namespace SeahawkSaverBackend.Application.Features.Subscription.Commands.Create;
using AutoMapper;
using FluentValidation;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Subscription.Commands.Create.DTOs;
using SeahawkSaverBackend.Application.Features.User.Queries.Specifications;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The command handler for the <see cref="CreateSubscriptionCommand"/>.
 * </summary>
 */
public sealed class CreateSubscriptionCommandHandler : CommandHandler<CreateSubscriptionCommand, CreateSubscriptionCommandResponse>
{
	private readonly IMapper mapper;

	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateSubscriptionCommandHandler"/> instance.
	 * </summary>
	 * <param name="transaction">The "unit of work" used during the command execution.</param>
	 * <param name="validator">An optional validator for the command. If provided, it will be used to validate the
	 * command before execution. Otherwise, no validation will occur.</param>
	 * <param name="mapper">The AutoMapper to use.</param>
	 */
	public CreateSubscriptionCommandHandler(ICommandTransaction transaction,
									  IValidator<CreateSubscriptionCommand>? validator,
									  IMapper mapper)
		: base(transaction, validator)
	{
		this.mapper = mapper;
	}

	protected override async Task<CreateSubscriptionCommandResponse> HandleAsync(CreateSubscriptionCommand request, CancellationToken cancellationToken)
	{
		var specification = new GetUserByIdSpecification(request.UserId);
		var user = await Transaction.UserRepository.SingleOrDefaultAsync(specification, cancellationToken);

		if (user == null)
		{
			throw new NotFoundException(nameof(User), request.UserId);
		}

		var subscription = mapper.Map<Subscription>(request.Subscription);
		subscription.SubscriptionId = Guid.NewGuid();
		subscription.UserId = user.UserId;

		await Transaction.SubscriptionRepository.AddAsync(subscription, cancellationToken);

		return mapper.Map<CreateSubscriptionCommandResponse>(subscription.SubscriptionId);
	}
}