namespace SeahawkSaverBackend.Application.Features.Saving.Commands.Delete;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;

/**
 * <summary>
 * A factory for the <see cref="DeleteSavingCommand"/>.
 * </summary>
 */
public static class DeleteSavingCommandFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="DeleteSavingCommand"/> instance.
	 * </summary>
	 * <param name="commandSettings">The command settings.</param>
	 * <param name="savingId">The id of the saving to delete.</param>
	 * <param name="userId">The id of the associate user.</param>
	 * <returns>A new <see cref="DeleteSavingCommand"/> isntance.</returns>
	 */
	public static DeleteSavingCommand Create(CommandSettings commandSettings, Guid savingId, Guid userId)
	{
		return new DeleteSavingCommand
		{
			CommandSettings = commandSettings,
			SavingId = savingId,
			UserId = userId
		};
	}
}