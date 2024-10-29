namespace SeahawkSaverBackend.Application.Features.User.Commands;
using FluentValidation;
using FluentValidation.Validators;

/**
 * <summary>
 * A collection of FluentValidation validation extension methods related to the
 * <see cref="SeahawkSaverBackend.Domain.Entities.User"/> entity.
 * </summary>
 */
public static class UserCommandRequestValidationExtensions
{
	/**
	 * <summary>
	 * Validates that the user id is provided.
	 * </summary>
	 */
	public static IRuleBuilderOptions<TDTO, Guid?> ValidateUserId<TDTO>(this IRuleBuilder<TDTO, Guid?> ruleBuilder)
		where TDTO : UserCommandRequest
	{
		return ruleBuilder.Must(userId => userId != Guid.Empty)
						  .WithMessage("The user id must be provided.");
	}

	/**
	 * <summary>
	 * Validates that the email is provided and is in the proper format.
	 * </summary>
	 */
	public static IRuleBuilderOptions<TDTO, string?> ValidateEmail<TDTO>(this IRuleBuilder<TDTO, string?> ruleBuilder)
		where TDTO : UserCommandRequest
	{
		return ruleBuilder.NotEmpty()
						  .WithMessage("The email address must be provided.")
						  .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
						  .WithMessage("The email address format is invalid.");
	}

	/**
	 * <summary>
	 * Validates that the first name is provided.
	 * </summary>
	 */
	public static IRuleBuilderOptions<TDTO, string?> ValidateFirstName<TDTO>(this IRuleBuilder<TDTO, string?> ruleBuilder)
		where TDTO : UserCommandRequest
	{
		return ruleBuilder.NotEmpty()
						  .WithMessage("The first name must be provided.");
	}

	/**
	 * <summary>
	 * Validates that the last name is provided.
	 * </summary>
	 */
	public static IRuleBuilderOptions<TDTO, string?> ValidateLastName<TDTO>(this IRuleBuilder<TDTO, string?> ruleBuilder)
		where TDTO : UserCommandRequest
	{
		return ruleBuilder.NotEmpty()
						  .WithMessage("The last name must be provided.");
	}

	/**
	 * <summary>
	 * Validates that a password is at least eight characters and contains at least one lowercase letter, one uppercase
	 * letter, one number, and one special character.
	 * </summary>
	 */
	public static IRuleBuilderOptions<TDTO, string?> ValidatePassword<TDTO>(this IRuleBuilder<TDTO, string?> ruleBuilder)
		where TDTO : UserCommandRequest
	{
		const string pattern = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";

		return ruleBuilder.Matches(pattern);
	}
}