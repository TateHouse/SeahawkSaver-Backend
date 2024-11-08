namespace SeahawkSaverBackend.Application.Features.Debt.Commands.Update.Validators;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.Debt.Commands.Update.DTOs;

/**
 * <summary>
 * A validator for the <see cref="UpdateDebtCommandDebtRequest"/>.
 * </summary>
 */
public sealed class UpdateDebtCommandDebtRequestValidator : AbstractValidator<UpdateDebtCommandDebtRequest>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateDebtCommandDebtRequestValidator"/> instance.
	 * </summary>
	 */
	public UpdateDebtCommandDebtRequestValidator()
	{
		RuleFor(request => (Guid?)request.UserId)
			.ValidateUserId();

		RuleFor(request => (Guid?)request.DebtId)
			.ValidateDebtId();

		RuleFor(request => (decimal?)request.Amount)
			.ValidateAmount();

		RuleFor(request => (DateTime?)request.DateTime)
			.ValidateDateTime();
	}
}