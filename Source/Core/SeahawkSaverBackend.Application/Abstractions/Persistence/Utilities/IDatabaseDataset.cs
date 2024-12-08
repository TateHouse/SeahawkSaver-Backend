namespace SeahawkSaverBackend.Application.Abstractions.Persistence.Utilities;
using SeahawkSaverBackend.Domain.Entities;

/**
 * An interface containing properties to retrieve entities to seed the database with.
 */
public interface IDatabaseDataset
{
	/**
	 * <summary>
	 * The <see cref="User"/> entities to seed the database with.
	 * </summary>
	 */
	public IReadOnlyList<User> Users { get; }

	/**
	 * <summary>
	 * The <see cref="Debt"/> entities to seed the database with.
	 * </summary>
	 */
	public IReadOnlyList<Debt> Debts { get; }

	/**
	 * <summary>
	 * The <see cref="Expense"/> entities to seed the database with.
	 * </summary>
	 */
	public IReadOnlyList<Expense> Expenses { get; }

	/**
	 * <summary>
	 * The <see cref="Income"/> entities to seed the database with.
	 * </summary>
	 */
	public IReadOnlyList<Income> Incomes { get; }

	/**
	 * <summary>
	 * The <see cref="Saving"/> entities to seed the database with.
	 * </summary>
	 */
	public IReadOnlyList<Saving> Savings { get; }

	/**
	 * <summary>
	 * The <see cref="Subscription"/> entities to seed the database with.
	 * </summary>
	 */
	public IReadOnlyList<Subscription> Subscriptions { get; }
}