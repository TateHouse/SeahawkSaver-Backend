namespace SeahawkSaverBackend.Application.Features.Saving.Commands.Delete;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Saving.Queries.Specifications;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The command handler for the <see cref="DeleteSavingCommand"/>.
 * </summary>
 */
public sealed class DeleteSavingCommandHandler : CommandHandler<DeleteSavingCommand, Unit>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="DeleteSavingCommandHandler"/> instance.
	 * </summary>
	 * <param name="transaction">The "unit of work" used during the command execution.</param>
	 */
	public DeleteSavingCommandHandler(ICommandTransaction transaction)
		: base(transaction, null)
	{

	}

	protected override async Task<Unit> HandleAsync(DeleteSavingCommand request, CancellationToken cancellationToken)
	{
		var specification = new GetSavingByIdSpecification(request.SavingId, request.UserId);
		var saving = await Transaction.SavingRepository.SingleOrDefaultAsync(specification, cancellationToken);

		if (saving == null)
		{
			throw new NotFoundException(nameof(Saving), request.SavingId);
		}

		await Transaction.SavingRepository.DeleteAsync(saving, cancellationToken);

		return Unit.Value;
	}
}