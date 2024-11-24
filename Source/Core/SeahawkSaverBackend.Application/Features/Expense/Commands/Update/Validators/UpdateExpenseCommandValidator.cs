namespace SeahawkSaverBackend.Application.Features.Expense.Commands.Update.Validators;
using FluentValidation;

/**
 * <summary>
 * A validator for the <see cref="UpdateExpenseCommand"/>.
 * </summary>
 */
public sealed class UpdateExpenseCommandValidator : AbstractValidator<UpdateExpenseCommand>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateExpenseCommandValidator"/> instance.
	 * </summary>
	 */
	public UpdateExpenseCommandValidator()
	{
		RuleFor(command => command.Expense)
			.SetValidator(new UpdateExpenseCommandExpenseRequestValidator());
	}
}