namespace SeahawkSaverBackend.Application.UnitTest.Features.User.Commands.Login;
using Ardalis.Specification;
using Moq;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Authentication;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.User.Commands.Login;
using SeahawkSaverBackend.Domain.Entities;
using SeahawkSaverBackend.Domain.Factories;

[TestFixture]
public sealed class LoginUserCommandHandlerTest
{
	private const string Email = "test.user@example.com";
	private const string Password = "#Password4Testing";

	private CommandSettings commandSettings;
	private Mock<ICommandTransaction> mockTransaction;
	private Mock<IPasswordHasher> mockPasswordHasher;
	private Mock<ITokenGenerator> mockTokenGenerator;
	private LoginUserCommandHandler commandHandler;

	[SetUp]
	public void SetUp()
	{
		commandSettings = new CommandSettings(true, true);
		mockTransaction = new Mock<ICommandTransaction>();
		mockPasswordHasher = new Mock<IPasswordHasher>();
		mockTokenGenerator = new Mock<ITokenGenerator>();
		commandHandler = new LoginUserCommandHandler(mockTransaction.Object,
													 null,
													 mockPasswordHasher.Object,
													 mockTokenGenerator.Object);
	}

	[Test]
	public async Task GivenEmailThatDoesNotExist_WhenHandle_ThenThrowsNotFoundException()
	{
		mockTransaction.Setup(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(() => null);

		var request = LoginUserCommandFactory.Create(commandSettings, LoginUserCommandHandlerTest.Email, LoginUserCommandHandlerTest.Password);

		Assert.ThrowsAsync<NotFoundException>(() => commandHandler.Handle(request, CancellationToken.None));

		mockTransaction.Verify(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()), Times.Once);
	}

	[Test]
	public async Task GivenEmailThatExistsAndInvalidPassword_WhenHandle_ThenThrowsUnauthorizedException()
	{
		var user = UserFactory.Create(Guid.NewGuid(), LoginUserCommandHandlerTest.Email, LoginUserCommandHandlerTest.Password);

		mockTransaction.Setup(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(user);

		mockPasswordHasher.Setup(mock => mock.Verify(It.IsAny<string>(), It.IsAny<string>()))
						  .Returns(false);

		var request = LoginUserCommandFactory.Create(commandSettings, user.Email, user.Password);

		Assert.ThrowsAsync<UnauthorizedException>(() => commandHandler.Handle(request, CancellationToken.None));

		mockTransaction.Verify(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()), Times.Once);
		mockPasswordHasher.Verify(mock => mock.Verify(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
	}

	[Test]
	public async Task GivenEmailThatExistsAndPasswordThatExists_WhenHandle_ThenReturnsTokenAndUserIdAndEmail()
	{
		var user = UserFactory.Create(Guid.NewGuid(), LoginUserCommandHandlerTest.Email, LoginUserCommandHandlerTest.Password);
		const string token = "TestToken";

		mockTransaction.Setup(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(user);

		mockPasswordHasher.Setup(mock => mock.Verify(It.IsAny<string>(), It.IsAny<string>()))
						  .Returns(true);

		mockTokenGenerator.Setup(mock => mock.GenerateToken(It.IsAny<User>()))
						  .Returns(token);

		var request = LoginUserCommandFactory.Create(commandSettings, user.Email, user.Password);
		var response = await commandHandler.Handle(request, CancellationToken.None);

		Assert.Multiple(() =>
		{
			Assert.That(response.Token, Is.EqualTo(token));
			Assert.That(response.User.UserId, Is.EqualTo(user.UserId));
			Assert.That(response.User.Email, Is.EqualTo(user.Email));
		});
	}
}