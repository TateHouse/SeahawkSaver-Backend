namespace SeahawkSaverBackend.Application.Features.Saving.Commands.Create;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.Saving.Commands.Create.DTOs;

/**
 * <summary>
 * A factory for the <see cref="CreateSavingCommand"/>.
 * </summary>
 */
public static class CreateSavingCommandFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateSavingCommand"/> instance.
	 * </summary>
	 * <param name="commandSettings">The command settings.</param>
	 * <param name="userId">The id of the associated user.</param>
	 * <param name="amount">The amount of saving.</param>
	 * <param name="dateTime">The date and time the saving was received.</param>
	 * <returns>A new <see cref="CreateSavingCommand"/> instance.</returns>
	 */
	public static CreateSavingCommand Create(CommandSettings commandSettings,
											 Guid userId,
											 decimal amount,
											 DateTime dateTime)
	{
		return new CreateSavingCommand
		{
			CommandSettings = commandSettings,
			UserId = userId,
			Saving = new CreateSavingCommandSavingRequest
			{
				Amount = amount,
				DateTime = dateTime
			}
		};
	}
}