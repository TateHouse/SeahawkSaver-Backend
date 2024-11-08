namespace SeahawkSaverBackend.Application.Features.Debt.Queries.List;
using AutoMapper;
using SeahawkSaverBackend.Application.Abstractions.Application.Queries;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Features.Debt.Queries.List.DTOs;
using SeahawkSaverBackend.Application.Features.Debt.Queries.Specifications;

/**
 * <summary>
 * The query handler for the <see cref="ListDebtQuery"/>.
 * </summary>
 */
public sealed class ListDebtQueryHandler : QueryHandler<ListDebtQuery, ListDebtQueryResponse>
{
	/**
	 * <summary>
	 * instantiates a new <see cref="ListDebtQueryHandler"/> instance.
	 * </summary>
	 * <param name="transaction">the "unit of work" used during query execution.</param>
	 * <param name="mapper">the automapper to use.</param>
	 */
	public ListDebtQueryHandler(IQueryTransaction transaction, IMapper mapper)
		: base(transaction, mapper)
	{

	}

	protected override async Task<ListDebtQueryResponse> HandleAsync(ListDebtQuery request, CancellationToken cancellationToken)
	{
		var specification = new ListDebtForUserIdSpecification(request.UserId);
		var debts = await Transaction.DebtRepository.ListAsync(specification, cancellationToken);

		return Mapper.Map<ListDebtQueryResponse>(debts);
	}
}