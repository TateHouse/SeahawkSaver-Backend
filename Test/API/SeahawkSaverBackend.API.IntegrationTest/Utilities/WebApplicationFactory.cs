namespace SeahawkSaverBackend.API.IntegrationTest.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Utilities;

/**
 * <summary>
 * A custom <see cref="WebApplicationFactory{TEntryPoint}"/> for the API integration tests.
 * </summary>
 */
public sealed class WebApplicationFactory : WebApplicationFactory<Program>
{
	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		builder.ConfigureServices(configureServices =>
		{
			configureServices.AddScoped<IDatabaseDataset, InMemoryIntegrationTestDatabaseDataset>();
		});

		builder.ConfigureAppConfiguration((_, configure) =>
		{
			configure.AddJsonFile("AppSettings.IntegrationTest.json", false, true);
		});
	}
}