namespace SeahawkSaverBackend.Application.Features.Expense.Commands.Update.Validators;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.Expense.Commands.Update.DTOs;

/**
 * <summary>
 * A validator for the <see cref="UpdateExpenseCommandExpenseRequest"/>.
 * </summary>
 */
public sealed class UpdateExpenseCommandExpenseRequestValidator : AbstractValidator<UpdateExpenseCommandExpenseRequest>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateExpenseCommandExpenseRequestValidator"/> instance.
	 * </summary>
	 */
	public UpdateExpenseCommandExpenseRequestValidator()
	{
		RuleFor(request => (Guid?)request.UserId)
			.ValidateUserId();

		RuleFor(request => (Guid?)request.ExpenseId)
			.ValidateExpenseId();

		RuleFor(request => (decimal?)request.Amount)
			.ValidateAmount();

		RuleFor(request => (DateTime?)request.DateTime)
			.ValidateDateTime();
	}
}