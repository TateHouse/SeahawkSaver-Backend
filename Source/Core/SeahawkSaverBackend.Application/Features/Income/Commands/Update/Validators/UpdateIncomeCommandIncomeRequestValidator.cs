namespace SeahawkSaverBackend.Application.Features.Income.Commands.Update.Validators;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.Income.Commands.Update.DTOs;

/**
 * <summary>
 * A validator for the <see cref="UpdateIncomeCommandIncomeRequest"/>.
 * </summary>
 */
public sealed class UpdateIncomeCommandIncomeRequestValidator : AbstractValidator<UpdateIncomeCommandIncomeRequest>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateIncomeCommandIncomeRequestValidator"/> instance.
	 * </summary>
	 */
	public UpdateIncomeCommandIncomeRequestValidator()
	{
		RuleFor(request => (Guid?)request.UserId)
			.ValidateUserId();

		RuleFor(request => (Guid?)request.IncomeId)
			.ValidateIncomeId();

		RuleFor(request => (decimal?)request.Amount)
			.ValidateAmount();

		RuleFor(request => (DateTime?)request.DateTime)
			.ValidateDateTime();
	}
}