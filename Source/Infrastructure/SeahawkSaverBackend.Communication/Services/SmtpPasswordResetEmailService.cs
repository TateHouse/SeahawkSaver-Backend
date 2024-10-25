namespace SeahawkSaverBackend.Communication.Services;
using FluentEmail.Core;
using Microsoft.Extensions.Configuration;
using SeahawkSaverBackend.Application.Abstractions.Communication;

/**
 * <summary>
 * A service that sends a password reset email using SMTP.
 * </summary>
 */
public sealed class SmtpPasswordResetEmailService : IPasswordResetEmailService
{
	private readonly IConfiguration configuration;
	private readonly IFluentEmail fluentEmail;

	/**
	 * <summary>
	 * Instantiates a new <see cref="SmtpPasswordResetEmailService"/> instance.
	 * </summary>
	 * <param name="configuration">The application's key/value pair configurations.</param>
	 * <param name="fluentEmail">The fluent email to use.</param>
	 */
	public SmtpPasswordResetEmailService(IConfiguration configuration,
										 IFluentEmail fluentEmail)
	{
		this.configuration = configuration;
		this.fluentEmail = fluentEmail;
	}

	public async Task SendResetPasswordEmailAsync(string recipient,
												  string authenticationToken,
												  CancellationToken cancellationToken)
	{

		var resetLinkBaseUrl = configuration.GetValue<string>("EmailSettings:ResetLinkBaseUrl") ?? throw new InvalidOperationException("The EmailSettings:ResetLinkBaseUrl must be provided.");
		var resetLink = $"{resetLinkBaseUrl}?token={authenticationToken}";
		await fluentEmail.To(recipient)
						 .Subject("Seahawk Saver - Password Reset")
						 .Body($"Click on the following link to reset your password: {resetLink}")
						 .SendAsync(cancellationToken);
	}
}