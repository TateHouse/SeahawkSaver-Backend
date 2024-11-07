namespace SeahawkSaverBackend.Application.Features.Saving.Commands.Update.Validators;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.Saving.Commands.Update.DTOs;

/**
 * <summary>
 * A validator for the <see cref="UpdateSavingCommandSavingRequest"/>.
 * </summary>
 */
public sealed class UpdateSavingCommandSavingRequestValidator : AbstractValidator<UpdateSavingCommandSavingRequest>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateSavingCommandSavingRequestValidator"/> instance.
	 * </summary>
	 */
	public UpdateSavingCommandSavingRequestValidator()
	{
		RuleFor(request => (Guid?)request.UserId)
			.ValidateUserId();

		RuleFor(request => (Guid?)request.SavingId)
			.ValidateSavingId();

		RuleFor(request => (decimal?)request.Amount)
			.ValidateAmount();

		RuleFor(request => (DateTime?)request.DateTime)
			.ValidateDateTime();
	}
}