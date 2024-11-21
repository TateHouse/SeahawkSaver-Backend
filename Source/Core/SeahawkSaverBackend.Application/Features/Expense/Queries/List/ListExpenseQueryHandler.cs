namespace SeahawkSaverBackend.Application.Features.Expense.Queries.List;
using AutoMapper;
using SeahawkSaverBackend.Application.Abstractions.Application.Queries;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Features.Expense.Queries.List.DTOs;
using SeahawkSaverBackend.Application.Features.Expense.Queries.Specifications;

/**
 * <summary>
 * The query handler for the <see cref="ListExpenseQuery"/>.
 * </summary>
 */
public sealed class ListExpenseQueryHandler : QueryHandler<ListExpenseQuery, ListExpenseQueryResponse>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ListExpenseQueryHandler"/> instance.
	 * </summary>
	 * <param name="transaction">the "unit of work" used during query execution.</param>
	 * <param name="mapper">the automapper to use.</param>
	 */
	public ListExpenseQueryHandler(IQueryTransaction transaction, IMapper mapper)
		: base(transaction, mapper)
	{

	}

	protected override async Task<ListExpenseQueryResponse> HandleAsync(ListExpenseQuery request, CancellationToken cancellationToken)
	{
		var specification = new ListExpenseForUserIdSpecification(request.UserId);
		var expenses = await Transaction.ExpenseRepository.ListAsync(specification, cancellationToken);

		return Mapper.Map<ListExpenseQueryResponse>(expenses);
	}
}