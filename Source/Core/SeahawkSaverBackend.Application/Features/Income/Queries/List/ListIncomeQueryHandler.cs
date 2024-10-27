namespace SeahawkSaverBackend.Application.Features.Income.Queries.List;
using AutoMapper;
using SeahawkSaverBackend.Application.Abstractions.Application.Queries;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Features.Income.Queries.List.DTOs;
using SeahawkSaverBackend.Application.Features.Income.Queries.Specifications;

/**
 * <summary>
 * The query handler for the <see cref="ListIncomeQuery"/>.
 * </summary>
 */
public sealed class ListIncomeQueryHandler : QueryHandler<ListIncomeQuery, ListIncomeQueryResponse>
{
	/**
	 * <summary>
	 * instantiates a new <see cref="ListIncomeQueryHandler"/> instance.
	 * </summary>
	 * <param name="transaction">the "unit of work" used during query execution.</param>
	 * <param name="mapper">the automapper to use.</param>
	 */
	public ListIncomeQueryHandler(IQueryTransaction transaction, IMapper mapper)
		: base(transaction, mapper)
	{

	}

	protected override async Task<ListIncomeQueryResponse> HandleAsync(ListIncomeQuery request, CancellationToken cancellationToken)
	{
		var specification = new ListIncomeSpecification();
		var incomes = await Transaction.IncomeRepository.ListAsync(specification, cancellationToken);

		return Mapper.Map<ListIncomeQueryResponse>(incomes);
	}
}