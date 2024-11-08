namespace SeahawkSaverBackend.Application.Features.Debt.Commands.Create;
using AutoMapper;
using FluentValidation;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Debt.Commands.Create.DTOs;
using SeahawkSaverBackend.Application.Features.User.Queries.Specifications;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The command handler for the <see cref="CreateDebtCommand"/>.
 * </summary>
 */
public sealed class CreateDebtCommandHandler : CommandHandler<CreateDebtCommand, CreateDebtCommandResponse>
{
	private readonly IMapper mapper;

	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateDebtCommandHandler"/> instance.
	 * </summary>
	 * <param name="transaction">The "unit of work" used during the command execution.</param>
	 * <param name="validator">An optional validator for the command. If provided, it will be used to validate the
	 * command before execution. Otherwise, no validation will occur.</param>
	 * <param name="mapper">The AutoMapper to use.</param>
	 */
	public CreateDebtCommandHandler(ICommandTransaction transaction,
									  IValidator<CreateDebtCommand>? validator,
									  IMapper mapper)
		: base(transaction, validator)
	{
		this.mapper = mapper;
	}

	protected override async Task<CreateDebtCommandResponse> HandleAsync(CreateDebtCommand request, CancellationToken cancellationToken)
	{
		var specification = new GetUserByIdSpecification(request.UserId);
		var user = await Transaction.UserRepository.SingleOrDefaultAsync(specification, cancellationToken);

		if (user == null)
		{
			throw new NotFoundException(nameof(User), request.UserId);
		}

		var debt = mapper.Map<Debt>(request.Debt);
		debt.DebtId = Guid.NewGuid();
		debt.UserId = user.UserId;

		await Transaction.DebtRepository.AddAsync(debt, cancellationToken);

		return mapper.Map<CreateDebtCommandResponse>(debt.DebtId);
	}
}