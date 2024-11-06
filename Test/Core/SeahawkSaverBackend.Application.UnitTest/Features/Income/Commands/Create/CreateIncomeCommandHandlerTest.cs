namespace SeahawkSaverBackend.Application.UnitTest.Features.Income.Commands.Create;
using Ardalis.Specification;
using Moq;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Income.Commands.Create;
using SeahawkSaverBackend.Application.Features.Income.Commands.Create.Validators;
using SeahawkSaverBackend.Application.UnitTest.Utilities;
using SeahawkSaverBackend.Domain.Entities;
using SeahawkSaverBackend.Domain.Factories;

[TestFixture]
public sealed class CreateIncomeCommandHandlerTest
{
	private Mock<ICommandTransaction> mocKTransaction;
	private CreateIncomeCommandHandler commandHandler;
	private CommandSettings commandSettings;

	[SetUp]
	public void SetUp()
	{
		mocKTransaction = new Mock<ICommandTransaction>();
		var mapper = MapperFactory.Create<CreateIncomeCommandProfile>();
		var validator = new CreateIncomeCommandValidator();
		commandHandler = new CreateIncomeCommandHandler(mocKTransaction.Object, validator, mapper);
		commandSettings = new CommandSettings(true, true);
	}

	[Test]
	public async Task GivenUserIdThatDoesNotExist_WhenHandle_ThenThrowsNotFoundException()
	{
		mocKTransaction.Setup(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(() => null);

		var request = CreateIncomeCommandFactory.Create(commandSettings, Guid.NewGuid(), 50, DateTime.Now.AddDays(-1));

		Assert.ThrowsAsync<NotFoundException>(() => commandHandler.Handle(request, CancellationToken.None));

		mocKTransaction.Verify(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()), Times.Once);
	}

	[Test]
	public async Task GivenUserIdThatExists_WhenHandle_ThenReturnsIncomeId()
	{
		var user = UserFactory.Create(Guid.NewGuid(), "test.user@gmail.com", "#Password4Testing", "TestFirstName", "TestLastName", false);

		mocKTransaction.Setup(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(user);

		mocKTransaction.Setup(mock => mock.IncomeRepository.AddAsync(It.IsAny<Income>(), It.IsAny<CancellationToken>()));

		var request = CreateIncomeCommandFactory.Create(commandSettings, user.UserId, 100, DateTime.Now.AddDays(-1));
		var response = await commandHandler.Handle(request, CancellationToken.None);

		Assert.That(response.IncomeId, Is.Not.Empty);

		mocKTransaction.Verify(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()), Times.Once);
		mocKTransaction.Verify(mock => mock.IncomeRepository.AddAsync(It.IsAny<Income>(), It.IsAny<CancellationToken>()), Times.Once);
	}
}