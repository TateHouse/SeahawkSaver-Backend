namespace SeahawkSaverBackend.Application.Features.User.Commands.Update.Validators;
using FluentValidation;
using SeahawkSaverBackend.Application.Features.User.Commands.Update.DTOs;

/**
 * <summary>
 * A validator for the <see cref="UpdateUserCommandUserRequest"/>.
 * </summary>
 */
public sealed class UpdateUserCommandUserRequestValidator : AbstractValidator<UpdateUserCommandUserRequest>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="UpdateUserCommandUserRequestValidator"/> instance.
	 * </summary>
	 */
	public UpdateUserCommandUserRequestValidator()
	{
		RuleFor(request => (Guid?)request.UserId)
			.ValidateUserId();

		RuleFor(request => request.Email)
			.ValidateEmail();

		RuleFor(request => request.FirstName)
			.ValidateFirstName();

		RuleFor(request => request.LastName)
			.ValidateLastName();
	}
}