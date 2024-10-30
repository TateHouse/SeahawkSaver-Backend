namespace SeahawkSaverBackend.Application.Features.User.Commands.Update.Validators;
using FluentValidation;

/**
 * <summary>
 * A validator for the <see cref="UpdateUserCommand"/>.
 * </summary>
 */
public sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateUserCommandValidator"/> instance.
	 * </summary>
	 */
	public UpdateUserCommandValidator()
	{
		RuleFor(command => command.User)
			.SetValidator(new UpdateUserCommandUserRequestValidator());
	}
}