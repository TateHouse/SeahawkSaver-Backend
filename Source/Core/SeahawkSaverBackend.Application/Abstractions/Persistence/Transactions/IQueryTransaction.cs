namespace SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Repositories;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * An interface containing properties that make up the "unit of work" for queries.
 * </summary>
 */
public interface IQueryTransaction
{
	/**
	 * <summary>
	 * A read-only repository for <see cref="User"/> entities.
	 * </summary>
	 */
	public IReadOnlyRepository<User> UserRepository { get; }

	/**
	 * <summary>
	 * A read-only repository for <see cref="Income"/> entities.
	 * </summary>
	 */
	public IReadOnlyRepository<Income> IncomeRepository { get; }

	/**
	 * <summary>
	 * A read-only repository for <see cref="Debt"/> entities.
	 * </summary>
	 */
	public IReadOnlyRepository<Debt> DebtRepository { get; }
}