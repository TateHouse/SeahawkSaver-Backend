namespace SeahawkSaverBackend.Application.UnitTest.Features.Saving.Commands.Delete;
using Ardalis.Specification;
using MediatR;
using Moq;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Saving.Commands.Delete;
using SeahawkSaverBackend.Domain.Entities;
using SeahawkSaverBackend.Domain.Factories;

[TestFixture]
public sealed class DeleteSavingCommandHandlerTest
{
	private Mock<ICommandTransaction> mockTransaction;
	private DeleteSavingCommandHandler commandHandler;
	private CommandSettings commandSettings;

	[SetUp]
	public void SetUp()
	{
		mockTransaction = new Mock<ICommandTransaction>();
		commandHandler = new DeleteSavingCommandHandler(mockTransaction.Object);
		commandSettings = new CommandSettings(true, true);
	}

	[Test]
	public async Task GivenSavingIdThatDoesNotExistAndUserIdThatDoesNotExist_WhenHandle_ThenThrowsNotFoundException()
	{
		mockTransaction.Setup(mock => mock.SavingRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Saving>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(() => null);

		var request = DeleteSavingCommandFactory.Create(commandSettings, Guid.NewGuid(), Guid.NewGuid());

		Assert.ThrowsAsync<NotFoundException>(() => commandHandler.Handle(request, CancellationToken.None));

		mockTransaction.Verify(mock => mock.SavingRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Saving>>(), It.IsAny<CancellationToken>()), Times.Once);
	}

	[Test]
	public async Task GivenSavingIdThatExistsAndUserIdThatExists_WhenHandle_ThenReturnsUnit()
	{
		var saving = SavingFactory.Create(Guid.NewGuid(), 100, DateTime.Now.AddDays(-1), Guid.NewGuid());

		mockTransaction.Setup(mock => mock.SavingRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Saving>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(saving);

		mockTransaction.Setup(mock => mock.SavingRepository.DeleteAsync(It.IsAny<Saving>(), It.IsAny<CancellationToken>()));

		var request = DeleteSavingCommandFactory.Create(commandSettings, saving.SavingId, saving.UserId);
		var response = await commandHandler.Handle(request, CancellationToken.None);

		Assert.That(response, Is.TypeOf<Unit>());

		mockTransaction.Verify(mock => mock.SavingRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Saving>>(), It.IsAny<CancellationToken>()), Times.Once);
		mockTransaction.Verify(mock => mock.SavingRepository.DeleteAsync(It.IsAny<Saving>(), It.IsAny<CancellationToken>()), Times.Once);
	}
}