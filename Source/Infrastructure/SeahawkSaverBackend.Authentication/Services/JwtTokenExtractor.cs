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
		var authorizationHeader = httpContext.Request.Headers["Authorization"].ToString();

		if (string.IsNullOrWhiteSpace(authorizationHeader) ||
			authorizationHeader.StartsWith("Bearer ") == false)
		{
			throw new InvalidOperationException("The authorization header was not provided or was not properly formatted.");
		}

		return authorizationHeader["Bearer ".Length..].Trim();
	}
}