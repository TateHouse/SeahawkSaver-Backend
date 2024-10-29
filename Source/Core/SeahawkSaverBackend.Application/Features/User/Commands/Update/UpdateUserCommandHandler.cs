namespace SeahawkSaverBackend.Application.Features.User.Commands.Update;
using AutoMapper;
using FluentValidation;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.User.Queries.Specifications;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The command handler for the <see cref="UpdateUserCommand"/>.
 * </summary>
 */
public sealed class UpdateUserCommandHandler : CommandHandler<UpdateUserCommand, Unit>
{
	private readonly IMapper mapper;

	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateUserCommandHandler"/> instance.
	 * </summary>
	 * <param name="transaction">The "unit of work" used during the command execution.</param>
	 * <param name="validator">An optional validator for the command. If provided, it will be used to validate the
	 * command before execution. Otherwise, no validation will occur.</param>
	 * <param name="mapper">The AutoMapper to use.</param>
	 */
	public UpdateUserCommandHandler(ICommandTransaction transaction,
									IValidator<UpdateUserCommand>? validator,
									IMapper mapper)
		: base(transaction, validator)
	{
		this.mapper = mapper;
	}

	protected override async Task<Unit> HandleAsync(UpdateUserCommand request, CancellationToken cancellationToken)
	{
		var specification = new GetUserByIdSpecification(request.User.UserId);
		var user = await Transaction.UserRepository.SingleOrDefaultAsync(specification, cancellationToken);

		if (user == null)
		{
			throw new NotFoundException(nameof(User), request.User.UserId);
		}

		mapper.Map(request.User, user);

		await Transaction.UserRepository.UpdateAsync(user, cancellationToken);

		return Unit.Value;
	}
}