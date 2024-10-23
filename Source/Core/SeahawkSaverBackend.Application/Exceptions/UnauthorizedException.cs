namespace SeahawkSaverBackend.Application.Exceptions;
/**
 * <summary>
 * An exception that is used for unauthorized scenarios.
 * </summary>
 */
public class UnauthorizedException : Exception
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UnauthorizedException"/> instance.
	 * </summary>
	 * <param name="message">An error message.</param>
	 */
	public UnauthorizedException(string? message)
		: base(message)
	{

	}
}