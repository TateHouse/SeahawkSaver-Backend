namespace SeahawkSaverBackend.Application.Features.User.Commands.Password.PerformReset.Validation;
using FluentValidation;

/**
 * <summary>
 * A validator for the <see cref="PasswordUserPerformResetCommand"/>.
 * </summary>
 */
public sealed class PasswordUserPerformResetCommandValidator : AbstractValidator<PasswordUserPerformResetCommand>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="PasswordUserPerformResetCommandValidator"/> instance.
	 * </summary>
	 */
	public PasswordUserPerformResetCommandValidator()
	{
		RuleFor(command => command.Data)
			.SetValidator(new PasswordUserPerformResetCommandRequestValidator());
	}
}