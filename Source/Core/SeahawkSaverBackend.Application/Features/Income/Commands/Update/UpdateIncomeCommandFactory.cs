namespace SeahawkSaverBackend.Application.Features.Income.Commands.Update;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.Income.Commands.Update.DTOs;

/**
 * <summary>
 * A factory for the <see cref="UpdateIncomeCommand"/>.
 * </summary>
 */
public static class UpdateIncomeCommandFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateIncomeCommandFactory"/> instance.
	 * </summary>
	 * <param name="commandSettings">The command settings.</param>
	 * <param name="userId">The id of the associated user.</param>
	 * <param name="incomeId">The income's id.</param>
	 * <param name="amount">The amount of income.</param>
	 * <param name="dateTime">The date and time the income was received.</param>
	 * <returns>A new <see cref="UpdateIncomeCommand"/> instance.</returns>
	 */
	public static UpdateIncomeCommand Create(CommandSettings commandSettings,
											 Guid userId,
											 Guid incomeId,
											 decimal amount,
											 DateTime dateTime)
	{
		return new UpdateIncomeCommand
		{
			CommandSettings = commandSettings,
			Income = new UpdateIncomeCommandIncomeRequest
			{
				UserId = userId,
				IncomeId = incomeId,
				Amount = amount,
				DateTime = dateTime
			}
		};
	}
}