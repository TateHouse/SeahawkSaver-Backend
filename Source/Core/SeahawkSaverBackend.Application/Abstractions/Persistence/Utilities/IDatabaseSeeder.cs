namespace SeahawkSaverBackend.Application.Abstractions.Persistence.Utilities;

/**
 * <summary>
 * An interface for seeding the database.
 * </summary>
 */
public interface IDatabaseSeeder
{
	/**
	 * <summary>
	 * Seeds the database with the specified <see cref="IDatabaseDataset"/>.
	 * </summary>
	 * <param name="databaseDataset">An instance of <see cref="IDatabaseDataset"/> to see the database with.</param>
	 * <exception cref="DbUpdateException">An error is encountered while saving to the database.</exception>
	 * <exception cref="DbUpdateConcurrencyException">A concurrency violation is encountered while saving to the database.
	 * A concurrency violation occurs when an unexpected number of rows are affected during save. This is usually because
	 * the data in the database has been modified since it was loaded into memory.</exception>
	 * <exception cref="OperationCanceledException">If the <see cref="CancellationToken"/> is cancelled.</exception>
	 */
	public Task SeedDatabaseAsync(IDatabaseDataset databaseDataset);
}