namespace SeahawkSaverBackend.Application.Features.Income.Commands.Delete;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;

/**
 * <summary>
 * A factory for the <see cref="DeleteIncomeCommand"/>.
 * </summary>
 */
public static class DeleteIncomeCommandFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="DeleteIncomeCommand"/> instance.
	 * </summary>
	 * <param name="commandSettings">The command settings.</param>
	 * <param name="incomeId">The id of the income to delete.</param>
	 * <param name="userId">The id of the associate user.</param>
	 * <returns>A new <see cref="DeleteIncomeCommand"/> isntance.</returns>
	 */
	public static DeleteIncomeCommand Create(CommandSettings commandSettings, Guid incomeId, Guid userId)
	{
		return new DeleteIncomeCommand
		{
			CommandSettings = commandSettings,
			IncomeId = incomeId,
			UserId = userId
		};
	}
}