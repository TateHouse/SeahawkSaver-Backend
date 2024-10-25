namespace SeahawkSaverBackend.Application.Abstractions.Authentication;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * An interface for validating security tokens.
 * </summary>
 */
public interface ITokenValidator
{
	/**
	 * <summary>
	 * Asynchronously validates the token.
	 * </summary>
	 * <param name="token">The token to validate.</param>
	 * <param name="isForPerformPasswordReset">Determines if the token is used for resetting a password.</param>
	 * <param name="cancellationToken">A token to cancel the operation.</param>
	 * <returns>A task that represents the asynchronous operation, and it contains the authorized user.</returns>
	 * <exception cref="NotFoundException">Thrown if the user id parsed contained within the token does not belong to
	 * a user in the database.</exception>
	 * <exception cref="UnauthorizedAccessException">Thrown if the token failed to validate, if the name identifier was
	 * not found, or some other unexpected error.</exception>
	 */
	public Task<User> ValidateTokenAsync(string token, bool isForPerformPasswordReset, CancellationToken cancellationToken);
}