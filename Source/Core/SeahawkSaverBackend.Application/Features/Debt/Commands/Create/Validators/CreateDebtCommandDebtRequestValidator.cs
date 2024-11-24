namespace SeahawkSaverBackend.Application.Features.Debt.Commands.Create.Validators;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.Debt.Commands.Create.DTOs;

/**
 * <summary>
 * A validator for the <see cref="CreateDebtCommandDebtRequest"/>.
 * </summary>
 */
public sealed class CreateDebtCommandDebtRequestValidator : AbstractValidator<CreateDebtCommandDebtRequest>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateDebtCommandDebtRequestValidator"/> instance.
	 * </summary>
	 */
	public CreateDebtCommandDebtRequestValidator()
	{
		RuleFor(request => (decimal?)request.Amount)
			.ValidateAmount();

		RuleFor(request => (DateTime?)request.DateTime)
			.ValidateDateTime();
	}
}