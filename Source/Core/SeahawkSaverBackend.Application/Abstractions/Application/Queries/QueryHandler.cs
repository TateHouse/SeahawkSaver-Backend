namespace SeahawkSaverBackend.Application.Abstractions.Application.Queries;
using AutoMapper;
using MediatR;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;

/**
 * <summary>
 * The base class for all query handlers.
 * </summary>
 * <remarks>
 * Each <see cref="QueryHandler{TQuery,TQueryResponse}"/> must have an associated <see cref="Query{TQueryResponse}"/>.
 * </remarks>
 * <typeparam name="TQuery">The type of the query.</typeparam>
 * <typeparam name="TQueryResponse">The type of the response that the <typeparamref name="TQuery"/> returns.</typeparam>
 */
public abstract class QueryHandler<TQuery, TQueryResponse> : IRequestHandler<TQuery, TQueryResponse>
	where TQuery : Query<TQueryResponse>
{
	protected readonly IQueryTransaction Transaction;
	protected readonly IMapper Mapper;

	/**
	 * <summary>
	 * Instantiates a new <see cref="QueryHandler{TQuery,TQueryResponse}"/> instance.
	 * </summary>
	 * <param name="transaction">The "unit of work" used during query execution.</param>
	 * <param name="mapper">The AutoMapper to use.</param>
	 */
	protected QueryHandler(IQueryTransaction transaction, IMapper mapper)
	{
		Transaction = transaction;
		Mapper = mapper;
	}

	/**
	 * <summary>
	 * Asynchronously handles the query.
	 * </summary>
	 * <remarks>
	 * This is where each query provides its implementation.
	 * </remarks>
	 * <param name="request">The query.</param>
	 * <param name="cancellationToken">A token to cancel the operation.</param>
	 * <typeparam name="TQueryResponse">The type of the response that the <typeparamref name="TQuery"/> returns.</typeparam>
	 * <returns>A task that represents the asynchronous operation, and it contains the response of type <typeparamref name="TQueryResponse"/>.</returns>
	 */
	protected abstract Task<TQueryResponse> HandleAsync(TQuery request, CancellationToken cancellationToken);

	public async Task<TQueryResponse> Handle(TQuery request, CancellationToken cancellationToken)
	{
		return await HandleAsync(request, cancellationToken);
	}
}