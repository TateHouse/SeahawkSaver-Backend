namespace SeahawkSaverBackend.API.IntegrationTest.Utilities;
using Microsoft.Extensions.DependencyInjection;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Utilities;
using SeahawkSaverBackend.Persistence;

/**
 * <summary>
 * The base class for all endpoint integration tests.
 * </summary>
 */
public abstract class EndpointTest
{
	protected WebApplicationFactory WebApplicationFactory { get; private set; }

	[SetUp]
	public virtual async Task SetUpAsync()
	{
		WebApplicationFactory = new WebApplicationFactory();

		await using var scope = WebApplicationFactory.Services.CreateAsyncScope();
		var databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
		await databaseContext.Database.EnsureDeletedAsync();
		await databaseContext.Database.EnsureCreatedAsync();
	}

	[TearDown]
	public virtual async Task TearDownAsync()
	{
		await WebApplicationFactory.DisposeAsync();
	}

	/**
	 * <summary>
	 * Asynchronously seeds the in-memory integration test database.
	 * </summary>
	 * <returns>A task that represents the asynchronous operation.</returns>
	 */
	protected async Task SeedDatabaseAsync()
	{
		await using var scope = WebApplicationFactory.Services.CreateAsyncScope();
		var databaseDataset = scope.ServiceProvider.GetRequiredService<IDatabaseDataset>();
		var databaseSeeder = scope.ServiceProvider.GetRequiredService<IDatabaseSeeder>();
		await databaseSeeder.SeedDatabaseAsync(databaseDataset);
	}
}