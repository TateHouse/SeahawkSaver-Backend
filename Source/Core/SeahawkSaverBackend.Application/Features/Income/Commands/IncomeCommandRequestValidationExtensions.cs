namespace SeahawkSaverBackend.Application.Features.Income.Commands;
using FluentValidation;

/**
 * A collection of FluentValidation validation extensions related to the
 * <see cref="SeahawkSaverBackend.Domain.Entities.Income"/> entity.
 */
public static class IncomeCommandRequestValidationExtensions
{
	/**
	 * <summary>
	 * Validates that the user id is provided.
	 * </summary>
	 */
	public static IRuleBuilderOptions<TDTO, Guid?> ValidateUserId<TDTO>(this IRuleBuilder<TDTO, Guid?> ruleBuilder)
		where TDTO : IncomeCommandRequest
	{
		return ruleBuilder.Must(userId => userId != Guid.Empty)
						  .WithMessage("The user id must be provided.");
	}

	/**
	 * <summary>
	 * Validates that the income id is provided.
	 * </summary>
	 */
	public static IRuleBuilderOptions<TDTO, Guid?> ValidateIncomeId<TDTO>(this IRuleBuilder<TDTO, Guid?> ruleBuilder)
		where TDTO : IncomeCommandRequest
	{
		return ruleBuilder.Must(incomeId => incomeId != Guid.Empty)
						  .WithMessage("The income id must be provided.");
	}

	/**
	 * <summary>
	 * Validates that the amount is greater than zero.
	 * </summary>
	 */
	public static IRuleBuilderOptions<TDTO, decimal?> ValidateAmount<TDTO>(this IRuleBuilder<TDTO, decimal?> ruleBuilder)
		where TDTO : IncomeCommandRequest
	{
		return ruleBuilder.GreaterThan(0)
						  .WithMessage("The amount must be greater than zero.");
	}

	/**
	 * <summary>
	 * Validates that the date and time are not in the future and not more than thirty days in the past.
	 * </summary>
	 */
	public static IRuleBuilderOptions<TDTO, DateTime?> ValidateDateTime<TDTO>(this IRuleBuilder<TDTO, DateTime?> ruleBuilder)
		where TDTO : IncomeCommandRequest
	{
		var currentDateTime = DateTime.Now;
		var minimumDateTime = currentDateTime.AddDays(-30);

		return ruleBuilder.LessThan(currentDateTime)
						  .WithMessage("The date and time cannot be in the future.")
						  .GreaterThan(minimumDateTime)
						  .WithMessage($"The date and time cannot be before {minimumDateTime}.");
	}
}