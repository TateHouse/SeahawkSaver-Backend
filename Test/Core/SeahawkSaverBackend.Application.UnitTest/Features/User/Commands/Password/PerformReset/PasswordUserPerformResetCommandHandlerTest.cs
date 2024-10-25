namespace SeahawkSaverBackend.Application.UnitTest.Features.User.Commands.Password.PerformReset;
using Moq;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Authentication;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Features.User.Commands.Password.PerformReset;
using SeahawkSaverBackend.Domain.Entities;
using SeahawkSaverBackend.Domain.Factories;

[TestFixture]
public sealed class PasswordUserPerformResetCommandHandlerTest
{
	private CommandSettings commandSettings;
	private Mock<ICommandTransaction> mockTransaction;
	private Mock<ITokenValidator> mockTokenValidator;
	private Mock<IPasswordHasher> mockPasswordHasher;
	private PasswordUserPerformResetCommandHandler passwordUserPerformResetCommandHandler;

	[SetUp]
	public void SetUp()
	{
		commandSettings = new CommandSettings(true, true);
		mockTransaction = new Mock<ICommandTransaction>();
		mockTokenValidator = new Mock<ITokenValidator>();
		mockPasswordHasher = new Mock<IPasswordHasher>();
		passwordUserPerformResetCommandHandler = new PasswordUserPerformResetCommandHandler(mockTransaction.Object,
																							mockTokenValidator.Object,
																							mockPasswordHasher.Object);
	}

	[Test]
	public async Task GivenValidToken_WhenHandle_ThenUserPasswordIsUpdated()
	{
		var user = UserFactory.Create(Guid.NewGuid(), "test.user@example.com", "#Password4Testing", "TestFirstName", "TestLastName");
		const string updatedPassword = "#UpdatedPassword4TestingHash";

		mockTokenValidator.Setup(mock => mock.ValidateTokenAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
						  .ReturnsAsync(user);

		mockPasswordHasher.Setup(mock => mock.Hash(It.IsAny<string>()))
						  .Returns(updatedPassword);

		mockTransaction.Setup(mock => mock.UserRepository.UpdateAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()));

		var request = PasswordUserPerformResetCommandFactory.Create(commandSettings, "Token", user.Password);
		await passwordUserPerformResetCommandHandler.Handle(request, CancellationToken.None);

		mockTokenValidator.Verify(mock => mock.ValidateTokenAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
		mockPasswordHasher.Verify(mock => mock.Hash(It.IsAny<string>()), Times.Once);
		mockTransaction.Verify(mock => mock.UserRepository.UpdateAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()), Times.Once);
	}
}