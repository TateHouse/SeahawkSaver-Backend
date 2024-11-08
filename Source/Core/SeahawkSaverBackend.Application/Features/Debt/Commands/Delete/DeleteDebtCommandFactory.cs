namespace SeahawkSaverBackend.Application.Features.Debt.Commands.Delete;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;

/**
 * <summary>
 * A factory for the <see cref="DeleteDebtCommand"/>.
 * </summary>
 */
public static class DeleteDebtCommandFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="DeleteDebtCommand"/> instance.
	 * </summary>
	 * <param name="commandSettings">The command settings.</param>
	 * <param name="debtId">The id of the debt to delete.</param>
	 * <param name="userId">The id of the associate user.</param>
	 * <returns>A new <see cref="DeleteDebtCommand"/> isntance.</returns>
	 */
	public static DeleteDebtCommand Create(CommandSettings commandSettings, Guid debtId, Guid userId)
	{
		return new DeleteDebtCommand
		{
			CommandSettings = commandSettings,
			DebtId = debtId,
			UserId = userId
		};
	}
}