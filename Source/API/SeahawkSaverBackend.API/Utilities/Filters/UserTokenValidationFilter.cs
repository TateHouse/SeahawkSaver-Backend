namespace SeahawkSaverBackend.API.Utilities.Filters;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * An endpoint filter used to authenticate a bearer token within a request for users.
 * </summary>
 */
public sealed class UserTokenValidationFilter : TokenValidationFilter
{
	protected override void ValidateUser(User user)
	{
		var routeUserId = httpContext.Request.RouteValues["userId"]?.ToString();

		if (routeUserId == null || !Guid.TryParse(routeUserId, out var userId) || user.UserId != userId)
		{
			throw new UnauthorizedException("The provided user id does not match the authenticated user's id.");
		}
	}
}