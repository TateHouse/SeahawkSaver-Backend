namespace SeahawkSaverBackend.Communication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeahawkSaverBackend.Application.Abstractions.Communication;
using SeahawkSaverBackend.Communication.Services;
using System.Net.Mail;

/**
 * <summary>
 * A class for registering services.
 * </summary>
 */
public static class ServiceRegistration
{
	/**
	 * <summary>
	 * An extension method for <see cref="IServiceCollection"/> to register the <see cref="Communication"/> services.
	 * </summary>
	 * <param name="configuration">The application's key/value pair configurations.</param>
	 */
	public static IServiceCollection RegisterCommunicationServices(this IServiceCollection services,
																   IConfiguration configuration)
	{
		var fromEmail = configuration.GetValue<string>("EmailSettings:FromEmail") ?? throw new InvalidOperationException("The EmailSettings:FromEmail must be provided.");
		var enableSSL = configuration.GetValue<bool>("EmailSettings:EnableSSL");
		var port = configuration.GetValue<int>("EmailSettings:Port");

		if (port == 0)
		{
			throw new InvalidOperationException("The EmailSettings:Port must be provided.");
		}

		services.AddFluentEmail(fromEmail)
				.AddSmtpSender(new SmtpClient
				{
					Port = port,
					EnableSsl = enableSSL,
					DeliveryMethod = SmtpDeliveryMethod.Network,
				});

		services.AddScoped<IPasswordResetEmailService, SmtpPasswordResetEmailService>();

		return services;
	}
}