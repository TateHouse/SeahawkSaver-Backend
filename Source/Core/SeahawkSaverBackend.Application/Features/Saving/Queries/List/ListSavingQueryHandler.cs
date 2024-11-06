namespace SeahawkSaverBackend.Application.Features.Saving.Queries.List;
using AutoMapper;
using SeahawkSaverBackend.Application.Abstractions.Application.Queries;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Features.Saving.Queries.List.DTOs;
using SeahawkSaverBackend.Application.Features.Saving.Queries.Specifications;

/**
 * <summary>
 * The query handler for the <see cref="ListSavingQuery"/>.
 * </summary>
 */
public sealed class ListSavingQueryHandler : QueryHandler<ListSavingQuery, ListSavingQueryResponse>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ListSavingQueryHandler"/> instance.
	 * </summary>
	 * <param name="transaction">the "unit of work" used during query execution.</param>
	 * <param name="mapper">the automapper to use.</param>
	 */
	public ListSavingQueryHandler(IQueryTransaction transaction, IMapper mapper)
		: base(transaction, mapper)
	{

	}

	protected override async Task<ListSavingQueryResponse> HandleAsync(ListSavingQuery request, CancellationToken cancellationToken)
	{
		var specification = new ListSavingForUserIdSpecification(request.UserId);
		var savings = await Transaction.SavingRepository.ListAsync(specification, cancellationToken);

		return Mapper.Map<ListSavingQueryResponse>(savings);
	}
}