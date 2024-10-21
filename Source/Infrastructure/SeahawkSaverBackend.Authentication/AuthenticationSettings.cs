namespace SeahawkSaverBackend.Authentication;
using Microsoft.Extensions.Configuration;

/**
 * The authentication settings.
 */
public sealed record AuthenticationSettings
{
	/**
	 * <summary>
	 * The issuer of the jwt token.
	 * </summary>
	 */
	public string Issuer { get; }

	/**
	 * <summary>
	 * The audience of the jwt token.
	 * </summary>
	 */
	public string Audience { get; }

	/**
	 * <summary>
	 * The secret key used for signing the jwt token.
	 * </summary>
	 */
	public string SecretKey { get; }

	/**
	 * <summary>
	 * Instantiates a new <see cref="AuthenticationSettings"/> instance.
	 * </summary>
	 * <param name="configuration">The application's key/value pair configurations.</param>
	 * <exception cref="InvalidOperationException">Thrown if the JwtSettings:Issuer, JwtSettings:Audience, or
	 * JWT_SECRET_KEY environment variable is not set.</exception>
	 */
	public AuthenticationSettings(IConfiguration configuration)
	{
		Issuer = configuration.GetValue<string>("JwtSettings:Issuer") ?? throw new InvalidOperationException("The JwtSettings:Issuer must be provided.");
		Audience = configuration.GetValue<string>("JwtSettings:Audience") ?? throw new InvalidOperationException("The JwtSettings:Audience must be provided.");
		SecretKey = configuration["JWT_SECRET_KEY"] ?? throw new InvalidOperationException("The JWT_SECRET_KEY environment variable must be set.");
	}
}