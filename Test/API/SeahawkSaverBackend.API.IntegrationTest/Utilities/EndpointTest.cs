namespace SeahawkSaverBackend.API.IntegrationTest.Utilities;
using Microsoft.Extensions.DependencyInjection;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Utilities;
using SeahawkSaverBackend.Persistence;
using System.Net.Http.Json;

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

	/**
	 * <summary>
	 * Asynchronously sends a POST request to the specified <paramref name="url"/>.
	 * </summary>
	 * <param name="url">The url to send the request to.</param>
	 * <param name="request">The request to send to the endpoint.</param>
	 * <returns>A task that represents the asynchronous operation, and it contains the <see cref="HttpResponseMessage"/>
	 * returned by the endpoint.</returns>
	 */
	protected async Task<HttpResponseMessage> PostAsync<TRequest>(string url, TRequest request)
	{
		using var client = WebApplicationFactory.CreateClient();
		var content = JsonContent.Create(request);

		return await client.PostAsync(url, content);
	}
}