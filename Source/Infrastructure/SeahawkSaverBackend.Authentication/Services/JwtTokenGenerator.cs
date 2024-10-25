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
public sealed class JwtTokenGenerator : ITokenGenerator
{
	private readonly AuthenticationSettings authenticationSettings;
	private readonly DateTime now;

	/**
	 * <summary>
	 * Instantiates a new <see cref="JwtTokenGenerator"/> instance.
	 * </summary>
	 * <param name="authenticationSettings">The authentication settings.</param>
	 */
	public JwtTokenGenerator(AuthenticationSettings authenticationSettings)
	{
		this.authenticationSettings = authenticationSettings;
		now = DateTime.UtcNow;
	}

	public string GenerateToken(User user, DateTime expirationDateTime, bool isForPerformPasswordReset)
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

		if (isForPerformPasswordReset)
		{
			var claim = new KeyValuePair<string, object>("purpose", "password-reset");
			tokenDescriptor.Claims.Add(claim);
		}

		var tokenHandler = new JwtSecurityTokenHandler();
		var token = tokenHandler.CreateToken(tokenDescriptor);

		return tokenHandler.WriteToken(token);
	}

}