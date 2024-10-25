namespace SeahawkSaverBackend.Application.Features.User.Commands;
using FluentValidation;

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