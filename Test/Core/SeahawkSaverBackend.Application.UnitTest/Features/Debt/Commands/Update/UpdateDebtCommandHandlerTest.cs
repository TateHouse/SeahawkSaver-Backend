namespace SeahawkSaverBackend.Application.UnitTest.Features.Debt.Commands.Update;
using Ardalis.Specification;
using MediatR;
using Moq;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Debt.Commands.Update;
using SeahawkSaverBackend.Application.Features.Debt.Commands.Update.Validators;
using SeahawkSaverBackend.Application.UnitTest.Utilities;
using SeahawkSaverBackend.Domain.Entities;
using SeahawkSaverBackend.Domain.Factories;

[TestFixture]
public sealed class UpdateDebtCommandHandlerTest
{
	private Mock<ICommandTransaction> mockTransaction;
	private UpdateDebtCommandHandler commandHandler;
	private CommandSettings commandSettings;

	[SetUp]
	public void SetUp()
	{
		mockTransaction = new Mock<ICommandTransaction>();
		var validator = new UpdateDebtCommandValidator();
		var mapper = MapperFactory.Create<UpdateDebtCommandProfile>();
		commandHandler = new UpdateDebtCommandHandler(mockTransaction.Object, validator, mapper);
		commandSettings = new CommandSettings(true, true);
	}

	[Test]
	public async Task GivenDebtIdThatDoesNotExistOrUserIdThatDoesNotExist_WhenHandle_ThenThrowsNotFoundException()
	{
		mockTransaction.Setup(mock => mock.DebtRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Debt>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(() => null);

		var request = UpdateDebtCommandFactory.Create(commandSettings, Guid.NewGuid(), Guid.NewGuid(), 100, DateTime.Now.AddDays(-1));

		Assert.ThrowsAsync<NotFoundException>(() => commandHandler.Handle(request, CancellationToken.None));

		mockTransaction.Verify(mock => mock.DebtRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Debt>>(), It.IsAny<CancellationToken>()), Times.Once);
	}

	[Test]
	public async Task GivenValidRequest_WhenHandle_ThenReturnsUnit()
	{
		var debt = DebtFactory.Create(Guid.NewGuid(), 100, DateTime.Now.AddDays(-1), Guid.NewGuid());

		mockTransaction.Setup(mock => mock.DebtRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Debt>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(debt);

		mockTransaction.Setup(mock => mock.DebtRepository.UpdateAsync(It.IsAny<Debt>(), It.IsAny<CancellationToken>()));

		var request = UpdateDebtCommandFactory.Create(commandSettings, debt.UserId, debt.DebtId, debt.Amount, debt.DateTime);
		var response = await commandHandler.Handle(request, CancellationToken.None);

		Assert.That(response, Is.TypeOf<Unit>());

		mockTransaction.Verify(mock => mock.DebtRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Debt>>(), It.IsAny<CancellationToken>()), Times.Once);
		mockTransaction.Verify(mock => mock.DebtRepository.UpdateAsync(It.IsAny<Debt>(), It.IsAny<CancellationToken>()), Times.Once);
	}
}