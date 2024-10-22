namespace SeahawkSaverBackend.Persistence.Utilities;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Utilities;

/**
 * <summary>
 * A database seeder for an Entity Framework Core in-memory database.
 * </summary>
 */
public sealed class InMemoryDatabaseSeeder : IDatabaseSeeder
{
	private readonly DatabaseContext databaseContext;

	/**
	 * <summary>
	 * Instantiates a new <see cref="InMemoryDatabaseSeeder"/> instance.
	 * </summary>
	 * <param name="databaseContext">The application's <see cref="Microsoft.EntityFrameworkCore.DbContext"/>.</param>
	 */
	public InMemoryDatabaseSeeder(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}


	public async Task SeedDatabaseAsync(IDatabaseDataset databaseDataset)
	{
		await databaseContext.AddRangeAsync(databaseDataset.Users);
		await databaseContext.SaveChangesAsync();
	}
}