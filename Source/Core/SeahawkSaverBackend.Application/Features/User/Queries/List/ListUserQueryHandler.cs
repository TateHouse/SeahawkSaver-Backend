namespace SeahawkSaverBackend.Application.Features.User.Queries.List;
using AutoMapper;
using SeahawkSaverBackend.Application.Abstractions.Application.Queries;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Features.User.Queries.List.DTOs;
using SeahawkSaverBackend.Application.Features.User.Queries.Specifications;

/**
 * <summary>
 * The query handler for the <see cref="ListUserQueryHandler"/>.
 * </summary>
 */
public sealed class ListUserQueryHandler : QueryHandler<ListUserQuery, ListUserQueryResponse>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ListUserQueryHandler"/> instance.
	 * </summary>
	 * <param name="transaction">the "unit of work" used during query execution.</param>
	 * <param name="mapper">the automapper to use.</param>
	 */
	public ListUserQueryHandler(IQueryTransaction transaction, IMapper mapper)
		: base(transaction, mapper)
	{

	}

	protected override async Task<ListUserQueryResponse> HandleAsync(ListUserQuery request, CancellationToken cancellationToken)
	{
		var specification = new ListUserSpecification();
		var users = await Transaction.UserRepository.ListAsync(specification, cancellationToken);

		return Mapper.Map<ListUserQueryResponse>(users);
	}
}