namespace SeahawkSaverBackend.Application.Features.Debt.Commands.Delete;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Debt.Queries.Specifications;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The command handler for the <see cref="DeleteDebtCommand"/>.
 * </summary>
 */
public sealed class DeleteDebtCommandHandler : CommandHandler<DeleteDebtCommand, Unit>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="DeleteDebtCommandHandler"/> instance.
	 * </summary>
	 * <param name="transaction">The "unit of work" used during the command execution.</param>
	 */
	public DeleteDebtCommandHandler(ICommandTransaction transaction)
		: base(transaction, null)
	{

	}

	protected override async Task<Unit> HandleAsync(DeleteDebtCommand request, CancellationToken cancellationToken)
	{
		var specification = new GetDebtByIdSpecification(request.DebtId, request.UserId);
		var debt = await Transaction.DebtRepository.SingleOrDefaultAsync(specification, cancellationToken);

		if (debt == null)
		{
			throw new NotFoundException(nameof(Debt), request.DebtId);
		}

		await Transaction.DebtRepository.DeleteAsync(debt, cancellationToken);

		return Unit.Value;
	}
}