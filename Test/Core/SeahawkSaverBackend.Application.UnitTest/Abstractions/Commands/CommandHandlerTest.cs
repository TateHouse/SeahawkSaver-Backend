namespace SeahawkSaverBackend.Application.UnitTest.Abstractions.Commands;
using Moq;
using SeahawkSaverBackend.Application.Abstractions.Application.Commands;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Exceptions;

[TestFixture]
public sealed class CommandHandlerTest
{
	private Mock<ICommandTransaction> mockTransaction;
	private FakeCommandHandler handler;

	[SetUp]
	public void SetUp()
	{
		mockTransaction = new Mock<ICommandTransaction>();
		var validator = new FakeCommandValidator();
		handler = new FakeCommandHandler(mockTransaction.Object, validator);
	}

	[Test]
	public async Task GivenInvalidRequest_WhenHandle_ThenThrowsValidationException()
	{
		mockTransaction.Setup(mock => mock.RollbackTransactionAsync());

		var request = new FakeCommand
		{
			CommandSettings = new CommandSettings(true, true),
			Name = ""
		};

		Assert.ThrowsAsync<ValidationException>(() => handler.Handle(request, CancellationToken.None));

		mockTransaction.Verify(mock => mock.RollbackTransactionAsync(), Times.Once);
	}

	[Test]
	[TestCase(true, true, true)]
	[TestCase(false, false, false)]
	[TestCase(true, false, false)]
	[TestCase(false, true, true)]
	[TestCase(true, true, false)]
	[TestCase(false, true, false)]
	public async Task GivenValidRequest_WhenHandle_ThenReturnsTrue(bool hasTransactionStarted, bool save, bool commit)
	{
		mockTransaction.Setup(mock => mock.HasTransactionStarted)
					   .Returns(hasTransactionStarted);

		mockTransaction.Setup(mock => mock.SaveChangesAsync());
		mockTransaction.Setup(mock => mock.CommitTransactionAsync());

		var request = new FakeCommand
		{
			CommandSettings = new CommandSettings(save, commit),
			Name = "Test Command"
		};

		var response = await handler.Handle(request, CancellationToken.None);

		Assert.That(response, Is.True);

		mockTransaction.Verify(mock => mock.HasTransactionStarted, Times.Once);
		mockTransaction.Verify(mock => mock.SaveChangesAsync(), CommandHandlerTest.GetExpectedTimes(save));
		mockTransaction.Verify(mock => mock.CommitTransactionAsync(), CommandHandlerTest.GetExpectedTimes(commit));
	}

	private static Times GetExpectedTimes(bool value)
	{
		return value == true ? Times.Once() : Times.Never();
	}
}