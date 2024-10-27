namespace SeahawkSaverBackend.Application.Features.Income.Commands.Create.Validators;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.Income.Commands.Create.DTOs;

/**
 * <summary>
 * A validator for the <see cref="CreateIncomeCommandRequestValidator"/>.
 * </summary>
 */
public sealed class CreateIncomeCommandRequestValidator : AbstractValidator<CreateIncomeCommandRequest>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateIncomeCommandRequestValidator"/> instance.
	 * </summary>
	 */
	public CreateIncomeCommandRequestValidator()
	{
		RuleFor(request => (decimal?)request.Amount)
			.ValidateAmount();

		RuleFor(request => (DateTime?)request.DateTime)
			.ValidateDateTime();
	}
}