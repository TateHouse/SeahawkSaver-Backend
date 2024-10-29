namespace SeahawkSaverBackend.Application.UnitTest.Features.Income.Commands.Update;
using Ardalis.Specification;
using MediatR;
using Moq;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.Income.Commands.Update;
using SeahawkSaverBackend.Application.Features.Income.Commands.Update.Validators;
using SeahawkSaverBackend.Application.UnitTest.Utilities;
using SeahawkSaverBackend.Domain.Entities;
using SeahawkSaverBackend.Domain.Factories;

[TestFixture]
public sealed class UpdateIncomeCommandHandlerTest
{
	private Mock<ICommandTransaction> mockTransaction;
	private UpdateIncomeCommandHandler commandHandler;
	private CommandSettings commandSettings;

	[SetUp]
	public void SetUp()
	{
		mockTransaction = new Mock<ICommandTransaction>();
		var validator = new UpdateIncomeCommandValidator();
		var mapper = MapperFactory.Create<UpdateIncomeCommandProfile>();
		commandHandler = new UpdateIncomeCommandHandler(mockTransaction.Object, validator, mapper);
		commandSettings = new CommandSettings(true, true);
	}

	[Test]
	public async Task GivenIncomeIdThatDoesNotExistOrUserIdThatDoesNotExist_WhenHandle_ThenThrowsNotFoundException()
	{
		mockTransaction.Setup(mock => mock.IncomeRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Income>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(() => null);

		var request = UpdateIncomeCommandFactory.Create(commandSettings, Guid.NewGuid(), Guid.NewGuid(), 100, DateTime.Now.AddDays(-1));

		Assert.ThrowsAsync<NotFoundException>(() => commandHandler.Handle(request, CancellationToken.None));

		mockTransaction.Verify(mock => mock.IncomeRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Income>>(), It.IsAny<CancellationToken>()), Times.Once);
	}

	[Test]
	public async Task GivenValidRequest_WhenHandle_ThenReturnsUnit()
	{
		var income = IncomeFactory.Create(Guid.NewGuid(), 100, DateTime.Now.AddDays(-1), Guid.NewGuid());

		mockTransaction.Setup(mock => mock.IncomeRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Income>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(income);

		mockTransaction.Setup(mock => mock.IncomeRepository.UpdateAsync(It.IsAny<Income>(), It.IsAny<CancellationToken>()));

		var request = UpdateIncomeCommandFactory.Create(commandSettings, income.UserId, income.IncomeId, income.Amount, income.DateTime);
		var response = await commandHandler.Handle(request, CancellationToken.None);

		Assert.That(response, Is.TypeOf<Unit>());

		mockTransaction.Verify(mock => mock.IncomeRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<Income>>(), It.IsAny<CancellationToken>()), Times.Once);
		mockTransaction.Verify(mock => mock.IncomeRepository.UpdateAsync(It.IsAny<Income>(), It.IsAny<CancellationToken>()), Times.Once);
	}
}