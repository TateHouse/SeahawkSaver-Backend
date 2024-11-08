namespace SeahawkSaverBackend.Application.UnitTest.Features.Debt.Commands.Delete;
using Ardalis.Specification;
using MediatR;
using Moq;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Debt.Commands.Delete;
using SeahawkSaverBackend.Domain.Entities;
using SeahawkSaverBackend.Domain.Factories;

[TestFixture]
public sealed class DeleteDebtCommandHandlerTest
{
	private Mock<ICommandTransaction> mockTransaction;
	private DeleteDebtCommandHandler commandHandler;
	private CommandSettings commandSettings;

	[SetUp]
	public void SetUp()
	{
		mockTransaction = new Mock<ICommandTransaction>();
		commandHandler = new DeleteDebtCommandHandler(mockTransaction.Object);
		commandSettings = new CommandSettings(true, true);
	}

	[Test]
	public async Task GivenDebtIdThatDoesNotExistAndUserIdThatDoesNotExist_WhenHandle_ThenThrowsNotFoundException()
	{
		mockTransaction.Setup(mock => mock.DebtRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Debt>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(() => null);

		var request = DeleteDebtCommandFactory.Create(commandSettings, Guid.NewGuid(), Guid.NewGuid());

		Assert.ThrowsAsync<NotFoundException>(() => commandHandler.Handle(request, CancellationToken.None));

		mockTransaction.Verify(mock => mock.DebtRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Debt>>(), It.IsAny<CancellationToken>()), Times.Once);
	}

	[Test]
	public async Task GivenDebtIdThatExistsAndUserIdThatExists_WhenHandle_ThenReturnsUnit()
	{
		var debt = DebtFactory.Create(Guid.NewGuid(), 100, DateTime.Now.AddDays(-1), Guid.NewGuid());

		mockTransaction.Setup(mock => mock.DebtRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Debt>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(debt);

		mockTransaction.Setup(mock => mock.DebtRepository.DeleteAsync(It.IsAny<Debt>(), It.IsAny<CancellationToken>()));

		var request = DeleteDebtCommandFactory.Create(commandSettings, Guid.NewGuid(), Guid.NewGuid());
		var response = await commandHandler.Handle(request, CancellationToken.None);

		Assert.That(response, Is.TypeOf<Unit>());

		mockTransaction.Verify(mock => mock.DebtRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Debt>>(), It.IsAny<CancellationToken>()), Times.Once);
		mockTransaction.Verify(mock => mock.DebtRepository.DeleteAsync(It.IsAny<Debt>(), It.IsAny<CancellationToken>()));
	}
}