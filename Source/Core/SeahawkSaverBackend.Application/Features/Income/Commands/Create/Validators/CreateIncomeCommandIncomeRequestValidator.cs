namespace SeahawkSaverBackend.Application.Features.Income.Commands.Create.Validators;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.Income.Commands.Create.DTOs;

/**
 * <summary>
 * A validator for the <see cref="CreateIncomeCommandIncomeRequest"/>.
 * </summary>
 */
public sealed class CreateIncomeCommandIncomeRequestValidator : AbstractValidator<CreateIncomeCommandIncomeRequest>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateIncomeCommandIncomeRequestValidator"/> instance.
	 * </summary>
	 */
	public CreateIncomeCommandIncomeRequestValidator()
	{
		RuleFor(request => (decimal?)request.Amount)
			.ValidateAmount();

		RuleFor(request => (DateTime?)request.DateTime)
			.ValidateDateTime();
	}
}