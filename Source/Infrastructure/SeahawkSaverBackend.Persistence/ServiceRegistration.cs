namespace SeahawkSaverBackend.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Repositories;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Utilities;
using SeahawkSaverBackend.Persistence.Repositories;
using SeahawkSaverBackend.Persistence.Transactions;
using SeahawkSaverBackend.Persistence.Utilities;

/**
 * <summary>
 * A class for registering services.
 * </summary>
 */
public static class ServiceRegistration
{
	/**
	 * <summary>
	 * An extension method for <see cref="IServiceCollection"/> to register the <see cref="Persistence"/> services.
	 * </summary>
	 * <param name="configuration">The application's set of key/value pair configurations.</param>
	 * <exception cref="ArgumentException">Thrown if the database name or provider is null or whitespace.</exception>
	 * <exception cref="InvalidOperationException">Thrown if the database settings failed to parse.</exception>
	 * <exception cref="NotSupportedException">Thrown if the database provider is not supported.</exception>
	 */
	public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services,
																 IConfiguration configuration)
	{
		var databaseSettings = new DatabaseSettings(configuration);
		services.AddSingleton<DatabaseSettings>();

		services.AddDbContext<DatabaseContext>(optionsAction =>
		{
			ServiceRegistration.ConfigureDatabaseContext(optionsAction, databaseSettings);
		});

		switch (databaseSettings.Provider)
		{
			case "InMemory":
				services.AddScoped<IDatabaseDataset, InMemoryDatabaseDataset>();
				services.AddScoped<IDatabaseSeeder, InMemoryDatabaseSeeder>();

				break;

			default:
				throw new NotSupportedException($"Unsupported database provider: {databaseSettings.Provider}");
		}

		services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
		services.AddScoped(typeof(IReadOnlyRepository<>), typeof(ReadOnlyRepository<>));
		services.AddScoped<IQueryTransaction, QueryTransaction>();
		services.AddScoped<ICommandTransaction, CommandTransaction>();

		return services;
	}

	/**
	 * <summary>
	 * Configures the application's Entity Framework Core <see cref="DatabaseContext"/> and database seeder.
	 * </summary>
	 * <param name="optionsBuilder">The <see cref="DbContextOptionsBuilder"/>.</param>
	 * <param name="databaseSettings">The database settings.</param>
	 * <exception cref="NotSupportedException">Thrown if the database provider is not supported.</exception>
	 */
	private static void ConfigureDatabaseContext(DbContextOptionsBuilder optionsBuilder,
												 DatabaseSettings databaseSettings)
	{
		switch (databaseSettings.Provider)
		{
			case "InMemory":
				optionsBuilder.UseInMemoryDatabase(databaseSettings.Name);
				optionsBuilder.ConfigureWarnings(warningsConfigurationBuilderAction =>
				{
					warningsConfigurationBuilderAction.Ignore(InMemoryEventId.TransactionIgnoredWarning);
				});

				break;

			default:
				throw new NotSupportedException($"Unsupported database provider: {databaseSettings.Provider}");
		}
	}
}