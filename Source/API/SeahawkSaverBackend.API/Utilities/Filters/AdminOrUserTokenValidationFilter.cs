namespace SeahawkSaverBackend.API.Utilities.Filters;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Domain.Entities;

public sealed class AdminOrUserTokenValidationFilter : TokenValidationFilter
{
	protected override void ValidateUser(User user)
	{
		if (user.IsAdmin)
		{
			return;
		}

		var routeUserId = httpContext.Request.RouteValues["userId"]?.ToString();

		if (routeUserId != null && Guid.TryParse(routeUserId, out var userId) && user.UserId == userId)
		{
			return;
		}

		throw new UnauthorizedException("Invalid user or admin.");
	}
}