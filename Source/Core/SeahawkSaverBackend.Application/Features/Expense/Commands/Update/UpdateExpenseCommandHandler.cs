namespace SeahawkSaverBackend.Application.Features.Expense.Commands.Update;
using AutoMapper;
using FluentValidation;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Expense.Queries.Specifications;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The command handler for the <see cref="UpdateExpenseCommand"/>.
 * </summary>
 */
public sealed class UpdateExpenseCommandHandler : CommandHandler<UpdateExpenseCommand, Unit>
{
	private readonly IMapper mapper;

	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateExpenseCommandHandler"/> instance.
	 * </summary>
	 * <param name="transaction">The "unit of work" used during the command execution.</param>
	 * <param name="validator">An optional validator for the command. If provided, it will be used to validate the
	 * command before execution. Otherwise, no validation will occur.</param>
	 * <param name="mapper">The AutoMapper to use.</param>
	 */
	public UpdateExpenseCommandHandler(ICommandTransaction transaction,
									   IValidator<UpdateExpenseCommand>? validator,
									   IMapper mapper)
		: base(transaction, validator)
	{
		this.mapper = mapper;
	}

	protected override async Task<Unit> HandleAsync(UpdateExpenseCommand request, CancellationToken cancellationToken)
	{
		var specification = new GetExpenseByIdSpecification(request.Expense.ExpenseId, request.Expense.UserId);
		var expense = await Transaction.ExpenseRepository.SingleOrDefaultAsync(specification, cancellationToken);

		if (expense == null)
		{
			throw new NotFoundException(nameof(Expense), request.Expense.ExpenseId);
		}

		mapper.Map(request.Expense, expense);

		await Transaction.ExpenseRepository.UpdateAsync(expense, cancellationToken);

		return Unit.Value;
	}
}