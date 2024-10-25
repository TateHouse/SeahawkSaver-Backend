namespace SeahawkSaverBackend.Application.Abstractions.Communication;
/**
 * <summary>
 * An interface for sending the reset password link.
 * </summary>
 */
public interface IPasswordResetEmailService
{
	/**
	 * <summary>
	 * Asynchronously sends a password reset link to the provided email.
	 * </summary>
	 * <param name="recipient">The recipient email.</param>
	 * <param name="authenticationToken">The authentication token to attach to the reset password link.</param>
	 * <param name="cancellationToken">A token to cancel the operation.</param>
	 * <returns>A task that represents the asynchronous operation.</returns>
	 */
	public Task SendResetPasswordEmailAsync(string recipient,
											string authenticationToken,
											CancellationToken cancellationToken);
}