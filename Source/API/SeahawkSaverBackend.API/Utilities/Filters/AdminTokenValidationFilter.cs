namespace SeahawkSaverBackend.API.Utilities.Filters;
using SeahawkSaverBackend.Application.Abstractions.Authentication;
using SeahawkSaverBackend.Application.Exceptions;

/**
 * <summary>
 * An endpoint filter used to authenticate a bearer token within a request for admins.
 * </summary>
 */
public sealed class AdminTokenValidationFilter : IEndpointFilter
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

			if (user.IsAdmin)
			{
				return await next(context);
			}

			throw new UnauthorizedException("The provided user is not an admin.");
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