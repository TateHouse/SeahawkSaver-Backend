namespace SeahawkSaverBackend.Application.Features.Income.Commands.Update.Validators;
using FluentValidation;

/**
 * <summary>
 * A validator for the <see cref="UpdateIncomeCommand"/>.
 * </summary>
 */
public sealed class UpdateIncomeCommandValidator : AbstractValidator<UpdateIncomeCommand>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateIncomeCommandValidator"/> instance.
	 * </summary>
	 */
	public UpdateIncomeCommandValidator()
	{
		RuleFor(command => command.Income)
			.SetValidator(new UpdateIncomeCommandIncomeRequestValidator());
	}
}