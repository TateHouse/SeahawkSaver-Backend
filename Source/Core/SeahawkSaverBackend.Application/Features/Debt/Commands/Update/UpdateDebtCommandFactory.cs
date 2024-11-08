namespace SeahawkSaverBackend.Application.Features.Debt.Commands.Update;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.Debt.Commands.Update.DTOs;

/**
 * <summary>
 * A factory for the <see cref="UpdateDebtCommand"/>.
 * </summary>
 */
public static class UpdateDebtCommandFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateDebtCommandFactory"/> instance.
	 * </summary>
	 * <param name="commandSettings">The command settings.</param>
	 * <param name="userId">The id of the associated user.</param>
	 * <param name="debtId">The debt's id.</param>
	 * <param name="amount">The amount of debt.</param>
	 * <param name="dateTime">The date and time the debt was received.</param>
	 * <returns>A new <see cref="UpdateDebtCommand"/> instance.</returns>
	 */
	public static UpdateDebtCommand Create(CommandSettings commandSettings,
											 Guid userId,
											 Guid debtId,
											 decimal amount,
											 DateTime dateTime)
	{
		return new UpdateDebtCommand
		{
			CommandSettings = commandSettings,
			Debt = new UpdateDebtCommandDebtRequest
			{
				UserId = userId,
				DebtId = debtId,
				Amount = amount,
				DateTime = dateTime
			}
		};
	}
}