namespace SeahawkSaverBackend.Application.Features.Income.Commands.Create.Validators;
using FluentValidation;

/**
 * <summary>
 * A validator for the <see cref="CreateIncomeCommand"/>.
 * </summary>
 */
public sealed class CreateIncomeCommandValidator : AbstractValidator<CreateIncomeCommand>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateIncomeCommandValidator"/> instance.
	 * </summary>
	 */
	public CreateIncomeCommandValidator()
	{
		RuleFor(command => command.Income)
			.SetValidator(new CreateIncomeCommandRequestValidator());
	}
}