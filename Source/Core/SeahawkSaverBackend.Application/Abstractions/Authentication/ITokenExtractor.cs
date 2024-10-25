namespace SeahawkSaverBackend.Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Http;

/**
 * <summary>
 * An interface for extracting tokens from the authorization header.
 * </summary>
 */
public interface ITokenExtractor
{
	/**
	 * <summary>
	 * Extracts a token from the authorization header.
	 * </summary>
	 * <param name="httpContext">The HTTP request with the token in the authorization header.</param>
	 * <returns>The token.</returns>
	 * <exception cref="InvalidOperationException">Thrown if the authorization header was not provided or was not
	 * properly formatted.</exception>
	 */
	public string ExtractToken(HttpContext httpContext);
}