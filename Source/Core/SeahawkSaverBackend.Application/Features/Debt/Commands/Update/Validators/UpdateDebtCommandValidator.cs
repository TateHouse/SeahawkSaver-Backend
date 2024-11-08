namespace SeahawkSaverBackend.Application.Features.Debt.Commands.Update.Validators;
using FluentValidation;

/**
 * <summary>
 * A validator for the <see cref="UpdateDebtCommand"/>.
 * </summary>
 */
public sealed class UpdateDebtCommandValidator : AbstractValidator<UpdateDebtCommand>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateDebtCommandValidator"/> instance.
	 * </summary>
	 */
	public UpdateDebtCommandValidator()
	{
		RuleFor(command => command.Debt)
			.SetValidator(new UpdateDebtCommandDebtRequestValidator());
	}
}