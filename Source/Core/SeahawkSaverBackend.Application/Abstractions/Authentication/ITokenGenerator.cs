namespace SeahawkSaverBackend.Application.Abstractions.Authentication;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * An interface for generating security tokens.
 * </summary>
 */
public interface ITokenGenerator
{
	/**
	 * <summary>
	 * Generates a token for a user.
	 * </summary>
	 * <param name="user">The user to generate the token for.</param>
	 * <param name="expirationDateTime">When the token will expire.</param>
	 * <returns>A string representation of the generated token.</returns>
	 */
	public string GenerateToken(User user, DateTime expirationDateTime);
}