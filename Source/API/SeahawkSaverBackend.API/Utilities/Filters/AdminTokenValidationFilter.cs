namespace SeahawkSaverBackend.API.Utilities.Filters;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * An endpoint filter used to authenticate a bearer token within a request for admins.
 * </summary>
 */
public sealed class AdminTokenValidationFilter : TokenValidationFilter
{
	protected override void ValidateUser(User user)
	{
		if (user.IsAdmin == false)
		{
			throw new UnauthorizedException("The provided user is not an admin.");
		}
	}
}