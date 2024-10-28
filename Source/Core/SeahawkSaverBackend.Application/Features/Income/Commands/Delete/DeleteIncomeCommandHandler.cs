namespace SeahawkSaverBackend.Application.Features.Income.Commands.Delete;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Income.Queries.Specifications;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The command handler for the <see cref="DeleteIncomeCommand"/>.
 * </summary>
 */
public sealed class DeleteIncomeCommandHandler : CommandHandler<DeleteIncomeCommand, Unit>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="DeleteIncomeCommandHandler"/> instance.
	 * </summary>
	 * <param name="transaction">The "unit of work" used during the command execution.</param>
	 */
	public DeleteIncomeCommandHandler(ICommandTransaction transaction)
		: base(transaction, null)
	{

	}

	protected override async Task<Unit> HandleAsync(DeleteIncomeCommand request, CancellationToken cancellationToken)
	{
		var specification = new GetIncomeByIdSpecification(request.IncomeId, request.UserId);
		var income = await Transaction.IncomeRepository.SingleOrDefaultAsync(specification, cancellationToken);

		if (income == null)
		{
			throw new NotFoundException(nameof(Income), request.IncomeId);
		}

		await Transaction.IncomeRepository.DeleteAsync(income, cancellationToken);

		return Unit.Value;
	}
}