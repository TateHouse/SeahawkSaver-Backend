namespace SeahawkSaverBackend.Application.Features.Saving.Commands.Update.Validators;
using FluentValidation;

/**
 * <summary>
 * A validator for the <see cref="UpdateSavingCommand"/>.
 * </summary>
 */
public sealed class UpdateSavingCommandValidator : AbstractValidator<UpdateSavingCommand>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateSavingCommandValidator"/> instance.
	 * </summary>
	 */
	public UpdateSavingCommandValidator()
	{
		RuleFor(command => command.Saving)
			.SetValidator(new UpdateSavingCommandSavingRequestValidator());
	}
}