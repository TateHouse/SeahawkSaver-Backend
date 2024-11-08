namespace SeahawkSaverBackend.Application.UnitTest.Features.User.Commands.Update;
using Ardalis.Specification;
using MediatR;
using Moq;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;
using SeahawkSaverBackend.Application.Features.User.Commands.Update;
using SeahawkSaverBackend.Application.Features.User.Commands.Update.Validators;
using SeahawkSaverBackend.Application.UnitTest.Utilities;
using SeahawkSaverBackend.Domain.Entities;
using SeahawkSaverBackend.Domain.Factories;

[TestFixture]
public sealed class UpdateIncomeCommandHandlerTest
{
	private Mock<ICommandTransaction> mockTransaction;
	private UpdateUserCommandHandler commandHandler;
	private CommandSettings commandSettings;

	[SetUp]
	public void SetUp()
	{
		mockTransaction = new Mock<ICommandTransaction>();
		var validator = new UpdateUserCommandValidator();
		var mapper = MapperFactory.Create<UpdateUserCommandProfile>();
		commandHandler = new UpdateUserCommandHandler(mockTransaction.Object, validator, mapper);
		commandSettings = new CommandSettings(true, true);
	}

	[Test]
	public async Task GivenUserIdThatDoesNotExist_WhenHandle_ThenThrowsNotFoundException()
	{
		mockTransaction.Setup(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(() => null);

		var request = UpdateUserCommandFactory.Create(commandSettings, Guid.NewGuid(), "test.user@example.com", "TestFirstName", "TestLastName");

		Assert.ThrowsAsync<NotFoundException>(() => commandHandler.Handle(request, CancellationToken.None));

		mockTransaction.Verify(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()), Times.Once);
	}

	[Test]
	public async Task GivenUserIdThatExists_WhenHandle_ThenReturnsUnit()
	{
		var user = UserFactory.Create(Guid.NewGuid(), "test.user@example.com", "#Password4User", "TestFirstName", "TestLastName", false);

		mockTransaction.Setup(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(user);

		mockTransaction.Setup(mock => mock.UserRepository.UpdateAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()));

		var request = UpdateUserCommandFactory.Create(commandSettings, user.UserId, user.Email, user.FirstName, user.LastName);
		var response = await commandHandler.Handle(request, CancellationToken.None);

		Assert.That(response, Is.TypeOf<Unit>());

		mockTransaction.Verify(mock => mock.UserRepository.SingleOrDefaultAsync(It.IsAny<ISingleResultSpecification<User>>(), It.IsAny<CancellationToken>()), Times.Once);
		mockTransaction.Verify(mock => mock.UserRepository.UpdateAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()), Times.Once);
	}
}