namespace SeahawkSaverBackend.Authentication.Services;
using BCrypt.Net;
using SeahawkSaverBackend.Application.Abstractions.Authentication;

/**
 * <summary>
 * A class for hashing and verifying passwords using <see cref="BCrypt"/>.
 * </summary>
 */
public sealed class PasswordHasher : IPasswordHasher
{
	public string Hash(string password)
	{
		return BCrypt.HashPassword(password);
	}

	public bool Verify(string password, string hashedPassword)
	{
		return BCrypt.Verify(password, hashedPassword);
	}
}