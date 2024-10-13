namespace SeahawkSaverBackend.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Repositories;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Persistence.Repositories;
using SeahawkSaverBackend.Persistence.Transactions;

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
		var databaseSettings = configuration.GetSection("Database").Get<DatabaseSettings>();

		if (databaseSettings == null)
		{
			throw new InvalidOperationException("At least one fo the provided database settings was invalid.");
		}

		services.AddDbContext<DatabaseContext>(optionsAction =>
		{
			ServiceRegistration.ConfigureDatabaseContext(optionsAction, databaseSettings);
		});

		services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
		services.AddScoped(typeof(IReadOnlyRepository<>), typeof(ReadOnlyRepository<>));
		services.AddScoped<IQueryTransaction, QueryTransaction>();
		services.AddScoped<ICommandTransaction, CommandTransaction>();

		return services;
	}

	/**
	 * <summary>
	 * Configures the application's Entity Framework Core <see cref="DatabaseContext"/>.
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