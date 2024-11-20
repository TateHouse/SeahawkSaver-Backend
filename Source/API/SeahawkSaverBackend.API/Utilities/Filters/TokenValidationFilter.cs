namespace SeahawkSaverBackend.API.Utilities.Filters;
using SeahawkSaverBackend.Application.Abstractions.Authentication;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The base class for all token validation filters.
 * </summary>
 */
public abstract class TokenValidationFilter : IEndpointFilter
{
	protected HttpContext httpContext = null!;

	protected abstract void ValidateUser(User user);

	public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
	{
		httpContext = context.HttpContext;
		var tokenExtractor = httpContext.RequestServices.GetRequiredService<ITokenExtractor>();
		var tokenValidator = httpContext.RequestServices.GetRequiredService<ITokenValidator>();

		try
		{
			var token = tokenExtractor.ExtractToken(httpContext);
			var user = await tokenValidator.ValidateTokenAsync(token, false, httpContext.RequestAborted);
			ValidateUser(user);

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