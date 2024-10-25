namespace SeahawkSaverBackend.Application.UnitTest.Features.User.Commands.Password.RequestReset;
using Ardalis.Specification;
using Moq;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Authentication;
using SeahawkSaverBackend.Application.Abstractions.Communication;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.User.Commands.Password.RequestReset;
using SeahawkSaverBackend.Domain.Entities;
using SeahawkSaverBackend.Domain.Factories;

[TestFixture]
public sealed class PasswordUserRequestResetCommandHandlerTest
{
	private const string Email = "test.user@example.com";

	private CommandSettings commandSettings;
	private Mock<ICommandTransaction> mockTransaction;
	private Mock<ITokenGenerator> mockTokenGenerator;
	private Mock<IPasswordResetEmailService> mockPasswordResetEmailService;
	private PasswordUserRequestResetCommandHandler passwordUserRequestResetCommandHandler;

	[SetUp]
	public void SetUp()
	{
		commandSettings = new CommandSettings(false, false);
		mockTransaction = new Mock<ICommandTransaction>();
		mockTokenGenerator = new Mock<ITokenGenerator>();
		mockPasswordResetEmailService = new Mock<IPasswordResetEmailService>();
		passwordUserRequestResetCommandHandler = new PasswordUserRequestResetCommandHandler(mockTransaction.Object,
																							mockTokenGenerator.Object,
																							mockPasswordResetEmailService.Object);
	}

	[Test]
	public async Task GivenEmailThatDoesNotExist_WhenHandle_ThenThrowsNotFoundException()
	{
		mockTransaction.Setup(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(() => null);

		var request = PasswordUserRequestResetCommandFactory.Create(commandSettings, PasswordUserRequestResetCommandHandlerTest.Email);
		Assert.ThrowsAsync<NotFoundException>(() => passwordUserRequestResetCommandHandler.Handle(request, CancellationToken.None));

		mockTransaction.Verify(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()), Times.Once);
	}

	[Test]
	public async Task GivenEmailThatExists_WhenHandle_ThenSendsPasswordResetEmail()
	{
		var user = UserFactory.Create(Guid.NewGuid(), PasswordUserRequestResetCommandHandlerTest.Email, "#Password4Testing", "TestFirstName", "TestLastName");
		mockTransaction.Setup(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(() => user);

		mockTokenGenerator.Setup(mock => mock.GenerateToken(It.IsAny<User>(), It.IsAny<DateTime>(), true))
						  .Returns("TestToken");

		mockPasswordResetEmailService.Setup(mock => mock.SendResetPasswordEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()));

		var request = PasswordUserRequestResetCommandFactory.Create(commandSettings, PasswordUserRequestResetCommandHandlerTest.Email);
		await passwordUserRequestResetCommandHandler.Handle(request, CancellationToken.None);

		mockTransaction.Verify(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()), Times.Once);
		mockTokenGenerator.Verify(mock => mock.GenerateToken(It.IsAny<User>(), It.IsAny<DateTime>(), true), Times.Once);
		mockPasswordResetEmailService.Verify(mock => mock.SendResetPasswordEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
	}
}