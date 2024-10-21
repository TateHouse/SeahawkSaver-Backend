namespace SeahawkSaverBackend.Domain.Factories;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * A factory for the <see cref="User"/> entity.
 * </summary>
 */
public static class UserFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="User"/> instance.
	 * </summary>
	 * <param name="userId">The user's id.</param>
	 * <param name="email">The user's email.</param>
	 * <param name="password">The hash of the user's password.</param>
	 */
	public static User Create(Guid userId, string email, string password)
	{
		return new User
		{
			UserId = userId,
			Email = email,
			Password = password
		};
	}
}