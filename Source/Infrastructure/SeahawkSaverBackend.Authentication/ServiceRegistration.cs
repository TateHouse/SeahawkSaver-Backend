namespace SeahawkSaverBackend.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

/**
 * <summary>
 * A class for registering services.
 * </summary>
 */
public static class ServiceRegistration
{
	/**
	 * <summary>
	 * An extension method for <see cref="IServiceCollection"/> to register the <see cref="Authentication"/> services.
	 * </summary>
	 */
	public static IServiceCollection RegisterAuthenticationServices(this IServiceCollection services,
																	IConfiguration configuration)
	{
		var authenticationSettings = new AuthenticationSettings(configuration);
		services.AddSingleton<AuthenticationSettings>();

		services.AddAuthentication(configureOptions =>
		{
			configureOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			configureOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		})
		.AddJwtBearer(configureOptions =>
		{
			configureOptions.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				ValidIssuer = authenticationSettings.Issuer,
				ValidAudience = authenticationSettings.Audience,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.SecretKey))
			};
		});

		services.AddAuthorization();

		return services;
	}
}