namespace SeahawkSaverBackend.Application.Features.Saving.Commands.Create;
using AutoMapper;
using FluentValidation;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Saving.Commands.Create.DTOs;
using SeahawkSaverBackend.Application.Features.User.Queries.Specifications;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The command handler for the <see cref="CreateSavingCommand"/>.
 * </summary>
 */
public sealed class CreateSavingCommandHandler : CommandHandler<CreateSavingCommand, CreateSavingCommandResponse>
{
	private readonly IMapper mapper;

	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateSavingCommandHandler"/> instance.
	 * </summary>
	 * <param name="transaction">The "unit of work" used during the command execution.</param>
	 * <param name="validator">An optional validator for the command. If provided, it will be used to validate the
	 * command before execution. Otherwise, no validation will occur.</param>
	 * <param name="mapper">The AutoMapper to use.</param>
	 */
	public CreateSavingCommandHandler(ICommandTransaction transaction,
									  IValidator<CreateSavingCommand>? validator,
									  IMapper mapper)
		: base(transaction, validator)
	{
		this.mapper = mapper;
	}

	protected override async Task<CreateSavingCommandResponse> HandleAsync(CreateSavingCommand request, CancellationToken cancellationToken)
	{
		var specification = new GetUserByIdSpecification(request.UserId);
		var user = await Transaction.UserRepository.SingleOrDefaultAsync(specification, cancellationToken);

		if (user == null)
		{
			throw new NotFoundException(nameof(User), request.UserId);
		}

		var saving = mapper.Map<Saving>(request.Saving);
		saving.SavingId = Guid.NewGuid();
		saving.UserId = user.UserId;

		await Transaction.SavingRepository.AddAsync(saving, cancellationToken);

		return mapper.Map<CreateSavingCommandResponse>(saving.SavingId);
	}
}