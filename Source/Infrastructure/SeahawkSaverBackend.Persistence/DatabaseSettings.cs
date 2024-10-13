namespace SeahawkSaverBackend.Persistence;
using Microsoft.Extensions.Configuration;

/**
 * <summary>
 * The database settings.
 * </summary>
 */
public sealed record DatabaseSettings
{
	/**
	 * <summary>
	 * The name of the database.
	 * </summary>
	 */
	public string Name { get; init; }

	/**
	 * <summary>
	 * The name of the database provider.
	 * </summary>
	 */
	public string Provider { get; init; }

	/**
	 * <summary>
	 * Whether the database should be seeded.
	 * </summary>
	 */
	public bool Seed { get; init; }

	/**
	 * <summary>
	 * Instantiates a new <see cref="DatabaseSettings"/> instance.
	 * </summary>
	 * <param name="configuration">The application's key/value pair configurations.</param>
	 * <exception cref="InvalidOperationException">Thrown if the Database:Name or Database:Provider are not provided.</exception>
	 */
	public DatabaseSettings(IConfiguration configuration)
	{
		Name = configuration.GetValue<string>("Database:Name") ?? throw new InvalidOperationException("The Database:Name must be provided.");
		Provider = configuration.GetValue<string>("Database:Provider") ?? throw new InvalidOperationException("The Database:Provider must be provided.");
		Seed = configuration.GetValue<bool>("Database:Seed");
	}
}