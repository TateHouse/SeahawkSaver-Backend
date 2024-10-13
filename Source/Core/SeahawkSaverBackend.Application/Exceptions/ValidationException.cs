namespace SeahawkSaverBackend.Application.Exceptions;
using FluentValidation.Results;

/**
 * <summary>
 * An exception that is used for validation errors.
 * </summary>
 */
public sealed class ValidationException : Exception
{
	/**
	 * <summary>
	 * The validation errors.
	 * </summary>
	 */
	public IEnumerable<string> ValidationErrors { get; init; }

	/**
	 * <summary>
	 * Instantiates a new <see cref="ValidationException"/> instance.
	 * </summary>
	 * <param name="validationResult">The validation result containing the validation failures.</param>
	 */
	public ValidationException(ValidationResult validationResult)
	{
		ValidationErrors = validationResult.Errors.Select(validationFailure => validationFailure.ErrorMessage);
	}
}