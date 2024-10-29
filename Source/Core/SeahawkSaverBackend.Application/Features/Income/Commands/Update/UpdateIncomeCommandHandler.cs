namespace SeahawkSaverBackend.Application.Features.Income.Commands.Update;
using AutoMapper;
using FluentValidation;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Income.Queries.Specifications;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The command handler for the <see cref="UpdateIncomeCommand"/>.
 * </summary>
 */
public sealed class UpdateIncomeCommandHandler : CommandHandler<UpdateIncomeCommand, Unit>
{
	private readonly IMapper mapper;

	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateIncomeCommandHandler"/> instance.
	 * </summary>
	 * <param name="transaction">The "unit of work" used during the command execution.</param>
	 * <param name="validator">An optional validator for the command. If provided, it will be used to validate the
	 * command before execution. Otherwise, no validation will occur.</param>
	 * <param name="mapper">The AutoMapper to use.</param>
	 */
	public UpdateIncomeCommandHandler(ICommandTransaction transaction,
									  IValidator<UpdateIncomeCommand>? validator,
									  IMapper mapper)
		: base(transaction, validator)
	{
		this.mapper = mapper;
	}

	protected override async Task<Unit> HandleAsync(UpdateIncomeCommand request, CancellationToken cancellationToken)
	{
		var specification = new GetIncomeByIdSpecification(request.Income.IncomeId, request.Income.UserId);
		var income = await Transaction.IncomeRepository.SingleOrDefaultAsync(specification, cancellationToken);

		if (income == null)
		{
			throw new NotFoundException(nameof(Income), request.Income.IncomeId);
		}

		mapper.Map(request.Income, income);

		await Transaction.IncomeRepository.UpdateAsync(income, cancellationToken);

		return Unit.Value;
	}
}