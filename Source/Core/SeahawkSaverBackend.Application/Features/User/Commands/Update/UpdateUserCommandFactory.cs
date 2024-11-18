namespace SeahawkSaverBackend.Application.Features.User.Commands.Update;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.User.Commands.Update.DTOs;

/**
 * <summary>
 * A factory for the <see cref="UpdateUserCommand"/>.
 * </summary>
 */
public static class UpdateUserCommandFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateUserCommandFactory"/> instance.
	 * </summary>
	 */
	public static UpdateUserCommand Create(CommandSettings commandSettings,
										   Guid userId,
										   string email,
										   string firstName,
										   string lastName,
										   bool isActive)
	{
		return new UpdateUserCommand
		{
			CommandSettings = commandSettings,
			User = new UpdateUserCommandUserRequest
			{
				UserId = userId,
				Email = email,
				FirstName = firstName,
				LastName = lastName,
				IsActive = isActive
			}
		};
	}
}