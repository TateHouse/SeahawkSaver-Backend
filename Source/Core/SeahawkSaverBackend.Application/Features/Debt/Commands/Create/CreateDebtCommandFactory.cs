namespace SeahawkSaverBackend.Application.Features.Debt.Commands.Create;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Features.Debt.Commands.Create.DTOs;

/**
 * <summary>
 * A factory for the <see cref="CreateDebtCommand"/>.
 * </summary>
 */
public static class CreateDebtCommandFactory
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateDebtCommand"/> instance.
	 * </summary>
	 * <param name="commandSettings">The command settings.</param>
	 * <param name="userId">The id of the associated user.</param>
	 * <param name="amount">The amount of debt.</param>
	 * <param name="dateTime">The date and time the debt was received.</param>
	 * <returns>A new <see cref="CreateDebtCommand"/> instance.</returns>
	 */
	public static CreateDebtCommand Create(CommandSettings commandSettings,
											 Guid userId,
											 decimal amount,
											 DateTime dateTime)
	{
		return new CreateDebtCommand
		{
			CommandSettings = commandSettings,
			UserId = userId,
			Debt = new CreateDebtCommandDebtRequest
			{
				Amount = amount,
				DateTime = dateTime
			}
		};
	}
}