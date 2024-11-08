namespace SeahawkSaverBackend.Application.Features.Debt.Commands.Update;
using AutoMapper;
using FluentValidation;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Debt.Queries.Specifications;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The command handler for the <see cref="UpdateDebtCommand"/>.
 * </summary>
 */
public sealed class UpdateDebtCommandHandler : CommandHandler<UpdateDebtCommand, Unit>
{
	private readonly IMapper mapper;

	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateDebtCommandHandler"/> instance.
	 * </summary>
	 * <param name="transaction">The "unit of work" used during the command execution.</param>
	 * <param name="validator">An optional validator for the command. If provided, it will be used to validate the
	 * command before execution. Otherwise, no validation will occur.</param>
	 * <param name="mapper">The AutoMapper to use.</param>
	 */
	public UpdateDebtCommandHandler(ICommandTransaction transaction,
									  IValidator<UpdateDebtCommand>? validator,
									  IMapper mapper)
		: base(transaction, validator)
	{
		this.mapper = mapper;
	}

	protected override async Task<Unit> HandleAsync(UpdateDebtCommand request, CancellationToken cancellationToken)
	{
		var specification = new GetDebtByIdSpecification(request.Debt.DebtId, request.Debt.UserId);
		var debt = await Transaction.DebtRepository.SingleOrDefaultAsync(specification, cancellationToken);

		if (debt == null)
		{
			throw new NotFoundException(nameof(Debt), request.Debt.DebtId);
		}

		mapper.Map(request.Debt, debt);

		await Transaction.DebtRepository.UpdateAsync(debt, cancellationToken);

		return Unit.Value;
	}
}