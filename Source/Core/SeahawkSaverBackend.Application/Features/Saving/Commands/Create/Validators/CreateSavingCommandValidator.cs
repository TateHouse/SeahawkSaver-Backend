namespace SeahawkSaverBackend.Application.Features.Saving.Commands.Create.Validators;
using FluentValidation;

/**
 * <summary>
 * A validator for the <see cref="CreateSavingCommand"/>.
 * </summary>
 */
public sealed class CreateSavingCommandValidator : AbstractValidator<CreateSavingCommand>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="CreateSavingCommandValidator"/> instance.
	 * </summary>
	 */
	public CreateSavingCommandValidator()
	{
		RuleFor(command => command.Saving)
			.SetValidator(new CreateSavingCommandSavingRequestValidator());
	}
}