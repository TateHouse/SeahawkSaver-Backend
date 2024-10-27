namespace SeahawkSaverBackend.Application.Features.Income.Commands.Create;
using AutoMapper;
using FluentValidation;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Income.Commands.Create.DTOs;
using SeahawkSaverBackend.Application.Features.User.Queries.Specifications;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The command handler for the <see cref="CreateIncomeCommand"/>.
 * </summary>
 */
public sealed class CreateIncomeCommandHandler : CommandHandler<CreateIncomeCommand, CreateIncomeCommandResponse>
{
	private readonly IMapper mapper;

	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateIncomeCommandHandler"/> instance.
	 * </summary>
	 * <param name="transaction">The "unit of work" used during the command execution.</param>
	 * <param name="validator">An optional validator for the command. If provided, it will be used to validate the
	 * command before execution. Otherwise, no validation will occur.</param>
	 * <param name="mapper">The AutoMapper to use.</param>
	 */
	public CreateIncomeCommandHandler(ICommandTransaction transaction,
									  IValidator<CreateIncomeCommand>? validator,
									  IMapper mapper)
		: base(transaction, validator)
	{
		this.mapper = mapper;
	}

	protected override async Task<CreateIncomeCommandResponse> HandleAsync(CreateIncomeCommand request, CancellationToken cancellationToken)
	{
		var specification = new GetUserByIdSpecification(request.UserId);
		var user = await Transaction.UserRepository.SingleOrDefaultAsync(specification, cancellationToken);

		if (user == null)
		{
			throw new NotFoundException(nameof(User), request.UserId);
		}

		var income = mapper.Map<Income>(request.Income);
		income.IncomeId = Guid.NewGuid();

		await Transaction.IncomeRepository.AddAsync(income, cancellationToken);

		var bridge = new UserIncomeBridge
		{
			UserId = request.UserId,
			IncomeId = income.IncomeId
		};

		await Transaction.UserIncomeBridgeRepository.AddAsync(bridge, cancellationToken);

		return mapper.Map<CreateIncomeCommandResponse>(income.IncomeId);
	}
}