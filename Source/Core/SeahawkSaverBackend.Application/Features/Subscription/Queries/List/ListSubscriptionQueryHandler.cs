namespace SeahawkSaverBackend.Application.Features.Subscription.Queries.List;
using AutoMapper;
using SeahawkSaverBackend.Application.Abstractions.Application.Queries;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Features.Subscription.Queries.List.DTOs;
using SeahawkSaverBackend.Application.Features.Subscription.Queries.Specifications;

/**
 * <summary>
 * The query handler for the <see cref="ListSubscriptionQuery"/>.
 * </summary>
 */
public sealed class ListSubscriptionQueryHandler : QueryHandler<ListSubscriptionQuery, ListSubscriptionQueryResponse>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ListSubscriptionQueryHandler"/> instance.
	 * </summary>
	 * <param name="transaction">the "unit of work" used during query execution.</param>
	 * <param name="mapper">the automapper to use.</param>
	 */
	public ListSubscriptionQueryHandler(IQueryTransaction transaction, IMapper mapper)
		: base(transaction, mapper)
	{

	}

	protected override async Task<ListSubscriptionQueryResponse> HandleAsync(ListSubscriptionQuery request, CancellationToken cancellationToken)
	{
		var specification = new ListSubscriptionForUserIdSpecification(request.UserId);
		var subscriptions = await Transaction.SubscriptionRepository.ListAsync(specification, cancellationToken);

		return Mapper.Map<ListSubscriptionQueryResponse>(subscriptions);
	}
}