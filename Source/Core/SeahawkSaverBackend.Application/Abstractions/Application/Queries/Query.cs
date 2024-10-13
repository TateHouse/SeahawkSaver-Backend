namespace SeahawkSaverBackend.Application.Abstractions.Application.Queries;
using MediatR;

/**
 * <summary>
 * The base class for queries.
 * </summary>
 * <remarks>
 * Each query must also have an associated <see cref="QueryHandler{TQuery,TQueryResponse}"/>.
 * </remarks>
 * <typeparam name="TQueryResponse">The type of the response that the <see cref="Query{TQueryResponse}"/> returns.</typeparam>
 */
public abstract class Query<TQueryResponse> : IRequest<TQueryResponse>
{

}