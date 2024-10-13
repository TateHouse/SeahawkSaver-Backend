namespace SeahawkSaverBackend.Persistence;
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

	public DatabaseSettings(string name, string provider)
	{
		if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(provider))
		{
			throw new ArgumentException("The Database:Name and Database:Provider must be provided.");
		}

		Name = name;
		Provider = provider;
	}
}