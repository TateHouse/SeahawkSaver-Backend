namespace SeahawkSaverBackend.Application.Features.Income.Commands.Create;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.Income.Commands.Create.DTOs;

/**
 * <summary>
 * A factory for the <see cref="CreateIncomeCommand"/>.
 * </summary>
 */
public static class CreateIncomeCommandFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateIncomeCommandFactory"/> instance.
	 * </summary>
	 * <param name="commandSettings">The command settings.</param>
	 * <param name="userId">The id of the associated user.</param>
	 * <param name="amount">The amount of income.</param>
	 * <param name="dateTime">The date and time the income was received.</param>
	 */
	public static CreateIncomeCommand Create(CommandSettings commandSettings,
											 Guid userId,
											 decimal amount,
											 DateTime dateTime)
	{
		return new CreateIncomeCommand
		{
			CommandSettings = commandSettings,
			UserId = userId,
			Income = new CreateIncomeCommandIncomeRequest
			{
				Amount = amount,
				DateTime = dateTime
			}
		};
	}
}