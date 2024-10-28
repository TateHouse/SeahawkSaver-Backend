namespace SeahawkSaverBackend.Application.UnitTest.Features.Income.Commands.Delete;
using Ardalis.Specification;
using MediatR;
using Moq;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Income.Commands.Delete;
using SeahawkSaverBackend.Domain.Entities;
using SeahawkSaverBackend.Domain.Factories;

[TestFixture]
public sealed class DeleteIncomeCommandHandlerTest
{
	private Mock<ICommandTransaction> mocKTransaction;
	private DeleteIncomeCommandHandler commandHandler;
	private CommandSettings commandSettings;

	[SetUp]
	public void SetUp()
	{
		mocKTransaction = new Mock<ICommandTransaction>();
		commandHandler = new DeleteIncomeCommandHandler(mocKTransaction.Object);
		commandSettings = new CommandSettings(true, true);
	}

	[Test]
	public async Task GivenIncomeIdThatDoesNotExistAndUserIdThatDoesNotExist_WhenHandle_ThenThrowsNotFoundException()
	{
		mocKTransaction.Setup(mock => mock.IncomeRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Income>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(() => null);

		var request = DeleteIncomeCommandFactory.Create(commandSettings, Guid.NewGuid(), Guid.NewGuid());

		Assert.ThrowsAsync<NotFoundException>(() => commandHandler.Handle(request, CancellationToken.None));

		mocKTransaction.Verify(mock => mock.IncomeRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Income>>(), It.IsAny<CancellationToken>()), Times.Once);
	}

	[Test]
	public async Task GivenIncomeIdThatExistsAndUserIdThatExists_WhenHandle_ThenReturnsUnit()
	{
		var income = IncomeFactory.Create(Guid.NewGuid(), 100, DateTime.Now.AddDays(-1), Guid.NewGuid());

		mocKTransaction.Setup(mock => mock.IncomeRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Income>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(income);

		mocKTransaction.Setup(mock => mock.IncomeRepository.DeleteAsync(It.IsAny<Income>(), It.IsAny<CancellationToken>()));

		var request = DeleteIncomeCommandFactory.Create(commandSettings, Guid.NewGuid(), Guid.NewGuid());
		var response = await commandHandler.Handle(request, CancellationToken.None);

		Assert.That(response, Is.TypeOf<Unit>());

		mocKTransaction.Verify(mock => mock.IncomeRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Income>>(), It.IsAny<CancellationToken>()), Times.Once);
		mocKTransaction.Verify(mock => mock.IncomeRepository.DeleteAsync(It.IsAny<Income>(), It.IsAny<CancellationToken>()));
	}
}