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
	 * The <see cref="Income"/> entities to seed the database with.
	 * </summary>
	 */
	public IReadOnlyList<Income> Incomes { get; }
}