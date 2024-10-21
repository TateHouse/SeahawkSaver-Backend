namespace SeahawkSaverBackend.Authentication.Services;
using Microsoft.IdentityModel.Tokens;
using SeahawkSaverBackend.Application.Abstractions.Authentication;
using SeahawkSaverBackend.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

/**
 * <summary>
 * A token generator that uses Json Web Tokens (JWT).
 * </summary>
 */
public sealed class TokenGenerator : ITokenGenerator
{
	private readonly AuthenticationSettings authenticationSettings;
	private readonly DateTime expires;

	/**
	 * <summary>
	 * Instantiates a new <see cref="TokenGenerator"/> instance.
	 * </summary>
	 * <param name="authenticationSettings">The authentication settings.</param>
	 */
	public TokenGenerator(AuthenticationSettings authenticationSettings)
	{
		this.authenticationSettings = authenticationSettings;
		expires = DateTime.UtcNow.AddHours(1);
	}

	public string GenerateToken(User user)
	{
		var claims = new[]
		{
			new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
		};

		var tokenHandler = new JwtSecurityTokenHandler();
		var key = Encoding.UTF8.GetBytes(authenticationSettings.SecretKey);
		var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
		var token = new JwtSecurityToken(authenticationSettings.Issuer,
										 authenticationSettings.Audience,
										 claims,
										 null,
										 expires,
										 signingCredentials);

		return tokenHandler.WriteToken(token);
	}
}