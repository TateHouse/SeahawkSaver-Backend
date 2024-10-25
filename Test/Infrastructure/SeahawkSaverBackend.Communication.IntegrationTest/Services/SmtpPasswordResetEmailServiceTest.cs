namespace SeahawkSaverBackend.Communication.IntegrationTest.Services;
using FluentEmail.Core;
using Microsoft.Extensions.Configuration;
using Moq;
using SeahawkSaverBackend.Communication.Services;

[TestFixture]
public sealed class SmtpPasswordResetEmailServiceTest
{
	private IConfiguration configuration;
	private Mock<IFluentEmail> mockFluentEmail;
	private SmtpPasswordResetEmailService smtpPasswordResetEmailService;

	[SetUp]
	public void SetUp()
	{
		var inMemorySettings = new Dictionary<string, string?>
		{
			{ "EmailSettings:FromEmail", "test.user@example.com" },
			{ "EmailSettings:EnableSSL", "false" },
			{ "EmailSettings:Port", "587" },
			{ "EmailSettings:ResetLinkBaseUrl", "https://reset-password" }
		};

		var configurationBuilder = new ConfigurationBuilder();
		configurationBuilder.AddInMemoryCollection(inMemorySettings);

		configuration = configurationBuilder.Build();

		mockFluentEmail = new Mock<IFluentEmail>();
		smtpPasswordResetEmailService = new SmtpPasswordResetEmailService(configuration, mockFluentEmail.Object);
	}

	[Test]
	public async Task GivenRecipientAndAuthenticationToken_WhenSendResetPasswordEmailAsync_ThenEmailIsSent()
	{
		mockFluentEmail.Setup(mock => mock.To(It.IsAny<string>()))
					   .Returns(mockFluentEmail.Object);

		mockFluentEmail.Setup(mock => mock.Subject(It.IsAny<string>()))
					   .Returns(mockFluentEmail.Object);

		mockFluentEmail.Setup(mock => mock.Body(It.IsAny<string>(), false))
					   .Returns(mockFluentEmail.Object);

		mockFluentEmail.Setup(mock => mock.SendAsync(It.IsAny<CancellationToken>()));

		var recipient = configuration["EmailSettings:FromEmail"]!;
		await smtpPasswordResetEmailService.SendResetPasswordEmailAsync(recipient, "TestToken", CancellationToken.None);

		mockFluentEmail.Verify(mock => mock.To(It.IsAny<string>()), Times.Once);
		mockFluentEmail.Verify(mock => mock.Subject(It.IsAny<string>()), Times.Once);
		mockFluentEmail.Verify(mock => mock.Body(It.IsAny<string>(), false), Times.Once);
		mockFluentEmail.Verify(mock => mock.SendAsync(It.IsAny<CancellationToken>()), Times.Once);
	}
}