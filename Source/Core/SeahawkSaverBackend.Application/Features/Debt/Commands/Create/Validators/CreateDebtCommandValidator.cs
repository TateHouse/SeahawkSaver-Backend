namespace SeahawkSaverBackend.Application.Features.Debt.Commands.Create.Validators;
using FluentValidation;

/**
 * <summary>
 * A validator for the <see cref="CreateDebtCommand"/>.
 * </summary>
 */
public sealed class CreateDebtCommandValidator : AbstractValidator<CreateDebtCommand>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateDebtCommandValidator"/> instance.
	 * </summary>
	 */
	public CreateDebtCommandValidator()
	{
		RuleFor(command => command.Debt)
			.SetValidator(new CreateDebtCommandDebtRequestValidator());
	}
}