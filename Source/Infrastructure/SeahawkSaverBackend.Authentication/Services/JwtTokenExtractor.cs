namespace SeahawkSaverBackend.Authentication.Services;
using Microsoft.AspNetCore.Http;
using SeahawkSaverBackend.Application.Abstractions.Authentication;

/**
 * <summary>
 * A JSON web token extractor.
 * </summary>
 */
public sealed class JwtTokenExtractor : ITokenExtractor
{
	public string ExtractToken(HttpContext httpContext)
	{
		var authorizationHeader = httpContext.Request.Headers["Bearer"].ToString();

		if (string.IsNullOrWhiteSpace(authorizationHeader))
		{
			throw new InvalidOperationException("The authorization header was not provided.");
		}

		return authorizationHeader;
	}
}