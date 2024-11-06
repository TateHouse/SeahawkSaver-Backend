namespace SeahawkSaverBackend.Application.Features.Saving.Commands.Create.Validators;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.Saving.Commands.Create.DTOs;

/**
 * <summary>
 * A validator for the <see cref="CreateSavingCommandSavingRequest"/>.
 * </summary>
 */
public sealed class CreateSavingCommandSavingRequestValidator : AbstractValidator<CreateSavingCommandSavingRequest>
{
	/**
	 * <summary>
	 * Instantiates a nnew <see cref="CreateSavingCommandSavingRequestValidator"/> instance.
	 * </summary>
	 */
	public CreateSavingCommandSavingRequestValidator()
	{
		RuleFor(request => (decimal?)request.Amount)
			.ValidateAmount();

		RuleFor(request => (DateTime?)request.DateTime)
			.ValidateDateTime();
	}
}