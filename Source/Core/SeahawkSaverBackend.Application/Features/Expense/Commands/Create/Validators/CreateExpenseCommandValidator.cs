namespace SeahawkSaverBackend.Application.Features.Expense.Commands.Create.Validators;
using FluentValidation;

/**
 * <summary>
 * A validator for the <see cref="CreateExpenseCommand"/>.
 * </summary>
 */
public sealed class CreateExpenseCommandValidator : AbstractValidator<CreateExpenseCommand>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateExpenseCommandValidator"/> instance.
	 * </summary>
	 */
	public CreateExpenseCommandValidator()
	{
		RuleFor(command => command.Expense)
			.SetValidator(new CreateExpenseCommandExpenseRequestValidator());
	}
}