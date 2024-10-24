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
	private readonly DateTime now;

	/**
	 * <summary>
	 * Instantiates a new <see cref="TokenGenerator"/> instance.
	 * </summary>
	 * <param name="authenticationSettings">The authentication settings.</param>
	 */
	public TokenGenerator(AuthenticationSettings authenticationSettings)
	{
		this.authenticationSettings = authenticationSettings;
		now = DateTime.UtcNow;
	}

	public string GenerateToken(User user, DateTime expirationDateTime)
	{
		var key = Encoding.UTF8.GetBytes(authenticationSettings.SecretKey);
		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(new[]
			{
				new Claim("sub", user.UserId.ToString())
			}),
			Issuer = authenticationSettings.Issuer,
			Audience = authenticationSettings.Audience,
			Claims = new Dictionary<string, object>
			{
				{ ClaimTypes.Email, user.Email }
			},
			IssuedAt = now,
			NotBefore = now,
			Expires = expirationDateTime,
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
		};

		var tokenHandler = new JwtSecurityTokenHandler();
		var token = tokenHandler.CreateToken(tokenDescriptor);

		return tokenHandler.WriteToken(token);
	}
}