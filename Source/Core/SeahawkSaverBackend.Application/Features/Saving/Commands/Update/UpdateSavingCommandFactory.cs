namespace SeahawkSaverBackend.Application.Features.Saving.Commands.Update;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.Saving.Commands.Update.DTOs;

/**
 * <summary>
 * A factory for the <see cref="UpdateSavingCommand"/>.
 * </summary>
 */
public static class UpdateSavingCommandFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateSavingCommandFactory"/> instance.
	 * </summary>
	 * <param name="commandSettings">The command settings.</param>
	 * <param name="userId">The id of the associated user.</param>
	 * <param name="savingId">The saving's id.</param>
	 * <param name="amount">The amount of saving.</param>
	 * <param name="dateTime">The date and time the saving was received.</param>
	 * <returns>A new <see cref="UpdateSavingCommand"/> instance.</returns>
	 */
	public static UpdateSavingCommand Create(CommandSettings commandSettings,
											 Guid userId,
											 Guid savingId,
											 decimal amount,
											 DateTime dateTime)
	{
		return new UpdateSavingCommand
		{
			CommandSettings = commandSettings,
			Saving = new UpdateSavingCommandSavingRequest
			{
				UserId = userId,
				SavingId = savingId,
				Amount = amount,
				DateTime = dateTime
			}
		};
	}
}