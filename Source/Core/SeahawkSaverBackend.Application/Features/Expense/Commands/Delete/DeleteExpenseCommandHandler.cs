namespace SeahawkSaverBackend.Application.Features.Expense.Commands.Delete;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Expense.Queries.Specifications;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The command handler for the <see cref="DeleteExpenseCommand"/>.
 * </summary>
 */
public sealed class DeleteExpenseCommandHandler : CommandHandler<DeleteExpenseCommand, Unit>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="DeleteExpenseCommandHandler"/> instance.
	 * </summary>
	 * <param name="transaction">The "unit of work" used during the command execution.</param>
	 */
	public DeleteExpenseCommandHandler(ICommandTransaction transaction)
		: base(transaction, null)
	{

	}

	protected override async Task<Unit> HandleAsync(DeleteExpenseCommand request, CancellationToken cancellationToken)
	{
		var specification = new GetExpenseByIdSpecification(request.ExpenseId, request.UserId);
		var expense = await Transaction.ExpenseRepository.SingleOrDefaultAsync(specification, cancellationToken);

		if (expense == null)
		{
			throw new NotFoundException(nameof(Expense), request.ExpenseId);
		}

		await Transaction.ExpenseRepository.DeleteAsync(expense, cancellationToken);

		return Unit.Value;
	}
}