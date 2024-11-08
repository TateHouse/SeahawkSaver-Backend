namespace SeahawkSaverBackend.Application.UnitTest.Features.Debt.Commands.Create;
using Ardalis.Specification;
using Moq;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Debt.Commands.Create;
using SeahawkSaverBackend.Application.Features.Debt.Commands.Create.Validators;
using SeahawkSaverBackend.Application.UnitTest.Utilities;
using SeahawkSaverBackend.Domain.Entities;
using SeahawkSaverBackend.Domain.Factories;

[TestFixture]
public sealed class CreateDebtCommandHandlerTest
{
	private Mock<ICommandTransaction> mocKTransaction;
	private CreateDebtCommandHandler commandHandler;
	private CommandSettings commandSettings;

	[SetUp]
	public void SetUp()
	{
		mocKTransaction = new Mock<ICommandTransaction>();
		var mapper = MapperFactory.Create<CreateDebtCommandProfile>();
		var validator = new CreateDebtCommandValidator();
		commandHandler = new CreateDebtCommandHandler(mocKTransaction.Object, validator, mapper);
		commandSettings = new CommandSettings(true, true);
	}

	[Test]
	public async Task GivenUserIdThatDoesNotExist_WhenHandle_ThenThrowsNotFoundException()
	{
		mocKTransaction.Setup(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(() => null);

		var request = CreateDebtCommandFactory.Create(commandSettings, Guid.NewGuid(), 50, DateTime.Now.AddDays(-1));

		Assert.ThrowsAsync<NotFoundException>(() => commandHandler.Handle(request, CancellationToken.None));

		mocKTransaction.Verify(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()), Times.Once);
	}

	[Test]
	public async Task GivenUserIdThatExists_WhenHandle_ThenReturnsDebtId()
	{
		var user = UserFactory.Create(Guid.NewGuid(), "test.user@gmail.com", "#Password4Testing", "TestFirstName", "TestLastName");

		mocKTransaction.Setup(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(user);

		mocKTransaction.Setup(mock => mock.DebtRepository.AddAsync(It.IsAny<Debt>(), It.IsAny<CancellationToken>()));

		var request = CreateDebtCommandFactory.Create(commandSettings, user.UserId, 100, DateTime.Now.AddDays(-1));
		var response = await commandHandler.Handle(request, CancellationToken.None);

		Assert.That(response.DebtId, Is.Not.Empty);

		mocKTransaction.Verify(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()), Times.Once);
		mocKTransaction.Verify(mock => mock.DebtRepository.AddAsync(It.IsAny<Debt>(), It.IsAny<CancellationToken>()), Times.Once);
	}
}