namespace SeahawkSaverBackend.API.Endpoints.Filters;
using SeahawkSaverBackend.Application.Abstractions.Authentication;
using SeahawkSaverBackend.Application.Exceptions;

/**
 * An endpoint filter for token validation.
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
			await tokenValidator.ValidateTokenAsync(token, false, httpContext.RequestAborted);

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