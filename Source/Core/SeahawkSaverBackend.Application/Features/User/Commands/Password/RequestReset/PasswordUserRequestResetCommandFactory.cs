namespace SeahawkSaverBackend.Application.Features.User.Commands.Password.RequestReset;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;

/**
 * <summary>
 * A factory for the <see cref="PasswordUserRequestResetCommand"/>.
 * </summary>
 */
public static class PasswordUserRequestResetCommandFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="PasswordUserRequestResetCommand"/> instance.
	 * </summary>
	 * <param name="commandSettings">The command settings.</param>
	 * <param name="email">The user's email.</param>
	 * <returns>A new <see cref="PasswordUserRequestResetCommand"/> instance.</returns>
	 */
	public static PasswordUserRequestResetCommand Create(CommandSettings commandSettings, string email)
	{
		return new PasswordUserRequestResetCommand
		{
			CommandSettings = commandSettings,
			Email = email
		};
	}
}