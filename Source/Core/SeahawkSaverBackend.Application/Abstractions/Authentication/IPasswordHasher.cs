namespace SeahawkSaverBackend.Application.Abstractions.Authentication;
/**
 * <summary>
 * An interface for hashing and verifying passwords.
 * </summary>
 */
public interface IPasswordHasher
{
	/**
	 * <summary>
	 * Hashes the password.
	 * </summary>
	 * <param name="password">The password to hash.</param>
	 * <returns>A string representation of the <paramref name="password"/> hash.</returns>
	 */
	public string Hash(string password);

	/**
	 * <summary>
	 * Checks if the provided non-hashed password matches the password hash stored for the user.
	 * </summary>
	 * <param name="password">The password to check.</param>
	 * <param name="hashedPassword">The hash of the stored password to check against.</param>
	 * <returns>True if the hash of the <paramref name="password"/> matches the password hash stored for the user.
	 * Otherwise, false.</returns>
	 */
	public bool Verify(string password, string hashedPassword);
}