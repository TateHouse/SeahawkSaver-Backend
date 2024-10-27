namespace SeahawkSaverBackend.API.Utilities.Filters;
using SeahawkSaverBackend.Application.Abstractions.Authentication;
using SeahawkSaverBackend.Application.Exceptions;

/**
 * <summary>
 * An endpoint filter used to authenticate a bearer token within a request.
 * </summary>
 */
public sealed class TokenValidationFilter : IEndpointFilter
{
	public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
	{
		var httpContext = context.HttpContext;
		var tokenExtractor = httpContext.RequestServices.GetRequiredService<ITokenExtractor>();
		var tokenValidator = httpContext.RequestServices.GetRequiredService<ITokenValidator>();

		try
		{
			var token = tokenExtractor.ExtractToken(httpContext);
			var user = await tokenValidator.ValidateTokenAsync(token, false, httpContext.RequestAborted);
			var routeUserId = httpContext.Request.RouteValues["userId"]?.ToString();

			if (routeUserId == null || !Guid.TryParse(routeUserId, out var userId) || user.UserId != userId)
			{
				throw new UnauthorizedException("The provided user id does not match the authenticated user's id.");
			}

			return await next(context);
		}
		catch (InvalidOperationException)
		{
			return Results.Unauthorized();
		}
		catch (NotFoundException)
		{
			return Results.Unauthorized();
		}
		catch (UnauthorizedException)
		{
			return Results.Unauthorized();
		}
	}
}