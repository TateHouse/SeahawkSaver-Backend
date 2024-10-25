namespace SeahawkSaverBackend.Application.Features.User.Commands.Password.PerformReset.Validation;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.User.Commands.Password.PerformReset.DTOs;

/**
 * <summary>
 * A validator for the <see cref="PasswordUserPerformResetCommandRequest"/>.
 * </summary>
 */
public sealed class PasswordUserPerformResetCommandRequestValidator : AbstractValidator<PasswordUserPerformResetCommandRequest>
{
	/**
	 * <summary>
	 * Instantiates a new<see cref="PasswordUserPerformResetCommandRequestValidator"/>.
	 * </summary>
	 */
	public PasswordUserPerformResetCommandRequestValidator()
	{
		RuleFor(request => request.Token)
			.NotEmpty();

		RuleFor(request => request.Password)
			.ValidatePassword();
	}
}