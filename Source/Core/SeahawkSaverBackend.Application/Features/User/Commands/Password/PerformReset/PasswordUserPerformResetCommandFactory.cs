namespace SeahawkSaverBackend.Application.Features.User.Commands.Password.PerformReset;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.User.Commands.Password.PerformReset.DTOs;

/**
 * <summary>
 * A factory for the <see cref="PasswordUserPerformResetCommand"/>.
 * </summary>
 */
public static class PasswordUserPerformResetCommandFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="PasswordUserPerformResetCommand"/> instance.
	 * </summary>
	 * <param name="commandSettings">The command settings.</param>
	 * <param name="token">The reset password authorization token.</param>
	 * <param name="password">The user's updated password.</param>
	 * <remarks>A new <see cref="PasswordUserPerformResetCommand"/> instance.</remarks>
	 */
	public static PasswordUserPerformResetCommand Create(CommandSettings commandSettings, string token, string password)
	{
		return new PasswordUserPerformResetCommand()
		{
			CommandSettings = commandSettings,
			Data = new PasswordUserPerformResetCommandRequest
			{
				Token = token,
				Password = password
			}
		};
	}
}