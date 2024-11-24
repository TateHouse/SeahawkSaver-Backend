namespace SeahawkSaverBackend.Application.Features.Expense.Commands.Create.Validators;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.Expense.Commands.Create.DTOs;

/**
 * <summary>
 * A validator for the <see cref="CreateExpenseCommandExpenseRequest"/>.
 * </summary>
 */
public sealed class CreateExpenseCommandExpenseRequestValidator : AbstractValidator<CreateExpenseCommandExpenseRequest>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateExpenseCommandExpenseRequestValidator"/> instance.
	 * </summary>
	 */
	public CreateExpenseCommandExpenseRequestValidator()
	{
		RuleFor(request => (decimal?)request.Amount)
			.ValidateAmount();

		RuleFor(request => (DateTime?)request.DateTime)
			.ValidateDateTime();
	}
}