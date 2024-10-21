namespace SeahawkSaverBackend.Application.Features.User.Commands.Login;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;

/**
 * <summary>
 * A factory for the <see cref="LoginUserCommand"/>.
 * </summary>
 */
public static class LoginUserCommandFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="LoginUserCommand"/> instance.
	 * </summary>
	 * <param name="commandSettings">The command settings.</param>
	 * <param name="email">The user's email.</param>
	 * <param name="password">The user's password.</param>
	 */
	public static LoginUserCommand Create(CommandSettings commandSettings, string email, string password)
	{
		return new LoginUserCommand
		{
			CommandSettings = commandSettings,
			Email = email,
			Password = password
		};
	}
}