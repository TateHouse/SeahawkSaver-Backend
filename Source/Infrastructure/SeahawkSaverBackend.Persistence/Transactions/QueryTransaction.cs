namespace SeahawkSaverBackend.Persistence.Transactions;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Repositories;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The "unit of work" for queries.
 * </summary>
 */
public sealed class QueryTransaction : IQueryTransaction
{
	public IReadOnlyRepository<User> UserRepository { get; }

	/**
	 * <summary>
	 * Instantiates a new <see cref="QueryTransaction"/> instance.
	 * </summary>
	 * <param name="userRepository">A read-only repository for <see cref="User"/> entities.</param>
	 */
	public QueryTransaction(IReadOnlyRepository<User> userRepository)
	{
		UserRepository = userRepository;
	}
}