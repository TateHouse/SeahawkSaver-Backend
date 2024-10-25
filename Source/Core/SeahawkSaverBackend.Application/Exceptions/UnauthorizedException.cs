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

	/**
	 * <summary>
	 * Instantiates a new <see cref="UnauthorizedException"/> instance.
	 * </summary>
	 * <param name="message">An error message.</param>
	 * <param name="exception">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
	 */
	public UnauthorizedException(string? message, Exception exception)
		: base(message, exception)
	{

	}
}