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
	private Mock<ICommandTransaction> mockTransaction;
	private DeleteIncomeCommandHandler commandHandler;
	private CommandSettings commandSettings;

	[SetUp]
	public void SetUp()
	{
		mockTransaction = new Mock<ICommandTransaction>();
		commandHandler = new DeleteIncomeCommandHandler(mockTransaction.Object);
		commandSettings = new CommandSettings(true, true);
	}

	[Test]
	public async Task GivenIncomeIdThatDoesNotExistAndUserIdThatDoesNotExist_WhenHandle_ThenThrowsNotFoundException()
	{
		mockTransaction.Setup(mock => mock.IncomeRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Income>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(() => null);

		var request = DeleteIncomeCommandFactory.Create(commandSettings, Guid.NewGuid(), Guid.NewGuid());

		Assert.ThrowsAsync<NotFoundException>(() => commandHandler.Handle(request, CancellationToken.None));

		mockTransaction.Verify(mock => mock.IncomeRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Income>>(), It.IsAny<CancellationToken>()), Times.Once);
	}

	[Test]
	public async Task GivenIncomeIdThatExistsAndUserIdThatExists_WhenHandle_ThenReturnsUnit()
	{
		var income = IncomeFactory.Create(Guid.NewGuid(), 100, DateTime.Now.AddDays(-1), Guid.NewGuid());

		mockTransaction.Setup(mock => mock.IncomeRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Income>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(income);

		mockTransaction.Setup(mock => mock.IncomeRepository.DeleteAsync(It.IsAny<Income>(), It.IsAny<CancellationToken>()));

		var request = DeleteIncomeCommandFactory.Create(commandSettings, Guid.NewGuid(), Guid.NewGuid());
		var response = await commandHandler.Handle(request, CancellationToken.None);

		Assert.That(response, Is.TypeOf<Unit>());

		mockTransaction.Verify(mock => mock.IncomeRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Income>>(), It.IsAny<CancellationToken>()), Times.Once);
		mockTransaction.Verify(mock => mock.IncomeRepository.DeleteAsync(It.IsAny<Income>(), It.IsAny<CancellationToken>()));
	}
}