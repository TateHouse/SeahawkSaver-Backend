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
	 * <param name="firstName">The user's first name.</param>
	 * <param name="lastName">The user's last name.</param>
	 * <param name="isAdmin">Specifies whether this user is an admin.</param>
	 * <returns>A new <see cref="User"/> instance.</returns>
	 */
	public static User Create(Guid userId,
							  string email,
							  string password,
							  string firstName,
							  string lastName,
							  bool isAdmin)
	{
		return new User
		{
			UserId = userId,
			Email = email,
			Password = password,
			FirstName = firstName,
			LastName = lastName,
			IsAdmin = isAdmin
		};
	}
}