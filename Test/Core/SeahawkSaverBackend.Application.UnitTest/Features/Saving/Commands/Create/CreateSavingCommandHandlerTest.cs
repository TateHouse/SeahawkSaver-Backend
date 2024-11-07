namespace SeahawkSaverBackend.Application.UnitTest.Features.Saving.Commands.Create;
using Ardalis.Specification;
using Moq;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Saving.Commands.Create;
using SeahawkSaverBackend.Application.Features.Saving.Commands.Create.Validators;
using SeahawkSaverBackend.Application.UnitTest.Utilities;
using SeahawkSaverBackend.Domain.Entities;
using SeahawkSaverBackend.Domain.Factories;

[TestFixture]
public sealed class CreateSavingCommandHandlerTest
{
	private Mock<ICommandTransaction> mockTransaction;
	private CreateSavingCommandHandler commandHandler;
	private CommandSettings commandSettings;

	[SetUp]
	public void SetUp()
	{
		mockTransaction = new Mock<ICommandTransaction>();
		var mapper = MapperFactory.Create<CreateSavingCommandProfile>();
		var validator = new CreateSavingCommandValidator();
		commandHandler = new CreateSavingCommandHandler(mockTransaction.Object, validator, mapper);
		commandSettings = new CommandSettings(true, true);
	}

	[Test]
	public async Task GivenUserIdThatDoesNotExist_WhenHandle_ThenThrowsNotFoundException()
	{
		mockTransaction.Setup(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(() => null);

		var request = CreateSavingCommandFactory.Create(commandSettings, Guid.NewGuid(), 50, DateTime.Now.AddDays(-1));

		Assert.ThrowsAsync<NotFoundException>(() => commandHandler.Handle(request, CancellationToken.None));

		mockTransaction.Verify(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()), Times.Once);
	}

	[Test]
	public async Task GivenUserIdThatExists_WhenHandle_ThenReturnsSavingId()
	{
		var user = UserFactory.Create(Guid.NewGuid(), "test.user@gmail.com", "#Password4Testing", "TestFirstName", "TestLastName", false);

		mockTransaction.Setup(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(user);

		mockTransaction.Setup(mock => mock.SavingRepository.AddAsync(It.IsAny<Saving>(), It.IsAny<CancellationToken>()));

		var request = CreateSavingCommandFactory.Create(commandSettings, user.UserId, 100, DateTime.Now.AddDays(-1));
		var response = await commandHandler.Handle(request, CancellationToken.None);

		Assert.That(response.SavingId, Is.Not.Empty);

		mockTransaction.Verify(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()), Times.Once);
		mockTransaction.Verify(mock => mock.SavingRepository.AddAsync(It.IsAny<Saving>(), It.IsAny<CancellationToken>()), Times.Once);
	}
}