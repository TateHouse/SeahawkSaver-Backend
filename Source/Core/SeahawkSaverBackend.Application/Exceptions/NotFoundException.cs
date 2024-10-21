namespace SeahawkSaverBackend.Application.Exceptions;
/**
 * <summary>
 * An exception that is used for when something, such as a database entity, was not found.
 * </summary>
 */
public class NotFoundException : Exception
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="NotFoundException"/> instance.
	 * </summary>
	 * <param name="name">The name, or type name, of what was not found.</param>
	 * <param name="key">The key of what was not found.</param>
	 */
	public NotFoundException(string name, object key)
		: base($"{name} ({key})")
	{

	}
}