namespace SeahawkSaverBackend.Application.Features.Saving.Commands.Update;
using AutoMapper;
using FluentValidation;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Saving.Queries.Specifications;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The command handler for the <see cref="UpdateSavingCommand"/>.
 * </summary>
 */
public sealed class UpdateSavingCommandHandler : CommandHandler<UpdateSavingCommand, Unit>
{
	private readonly IMapper mapper;

	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateSavingCommandHandler"/> instance.
	 * </summary>
	 * <param name="transaction">The "unit of work" used during the command execution.</param>
	 * <param name="validator">An optional validator for the command. If provided, it will be used to validate the
	 * command before execution. Otherwise, no validation will occur.</param>
	 * <param name="mapper">The AutoMapper to use.</param>
	 */
	public UpdateSavingCommandHandler(ICommandTransaction transaction,
									  IValidator<UpdateSavingCommand>? validator,
									  IMapper mapper)
		: base(transaction, validator)
	{
		this.mapper = mapper;
	}

	protected override async Task<Unit> HandleAsync(UpdateSavingCommand request, CancellationToken cancellationToken)
	{
		var specification = new GetSavingByIdSpecification(request.Saving.SavingId, request.Saving.UserId);
		var saving = await Transaction.SavingRepository.SingleOrDefaultAsync(specification, cancellationToken);

		if (saving == null)
		{
			throw new NotFoundException(nameof(Saving), request.Saving.SavingId);
		}

		mapper.Map(request.Saving, saving);

		await Transaction.SavingRepository.UpdateAsync(saving, cancellationToken);

		return Unit.Value;
	}
}