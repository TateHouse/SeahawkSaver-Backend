namespace SeahawkSaverBackend.Application.Abstractions.Application.Commands;
/**
 * <summary>
 * The settings for a <see cref="Command{TCommandResponse}"/>.
 * </summary>
 */
public sealed record CommandSettings
{
	/**
	 * <summary>
	 * A value indicating whether changes made by the command should be saved.
	 * </summary>
	 */
	public bool Save { get; }

	/**
	 * <summary>
	 * A value indicating whether the database transaction should be committed.
	 * </summary>
	 */
	public bool Commit { get; }

	/**
	 * <summary>
	 * Instantiates a new <see cref="CommandSettings"/> instance.
	 * </summary>
	 * <param name="save">A value indicating whether changes made by the command should be saved.</param>
	 * <param name="commit">A value indicating whether the database transaction should be committed.</param>
	 * <exception cref="ArgumentException">Thrown if the <paramref name="save"/> parameter is <c>false</c> but the
	 * <paramref name="commit"/> parameter is <c>true</c>.</exception>
	 */
	public CommandSettings(bool save, bool commit)
	{
		if (save == false && commit == true)
		{
			throw new ArgumentException("Save must be true if commit is true");
		}

		Save = save;
		Commit = commit;
	}
}