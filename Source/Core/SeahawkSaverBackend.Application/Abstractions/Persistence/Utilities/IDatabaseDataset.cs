namespace SeahawkSaverBackend.Application.Abstractions.Persistence.Utilities;
using SeahawkSaverBackend.Domain.Entities;

/**
 * An interface containing properties to retrieve entities to seed the database with.
 */
public interface IDatabaseDataset
{
	/**
	 * The <see cref="User"/> entities to seed the database with.
	 */
	public IReadOnlyList<User> Users { get; }
}