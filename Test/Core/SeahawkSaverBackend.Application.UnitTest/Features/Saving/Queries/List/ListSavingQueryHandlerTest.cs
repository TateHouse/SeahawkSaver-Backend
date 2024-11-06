namespace SeahawkSaverBackend.Application.UnitTest.Features.Saving.Queries.List;
using Ardalis.Specification;
using Moq;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Features.Saving.Queries.List;
using SeahawkSaverBackend.Application.UnitTest.Utilities;
using SeahawkSaverBackend.Domain.Entities;
using SeahawkSaverBackend.Domain.Factories;

[TestFixture]
public sealed class ListSavingQueryHandlerTest
{
	private Mock<IQueryTransaction> mockTransaction;
	private ListSavingQueryHandler queryHandler;

	[SetUp]
	public void SetUp()
	{
		mockTransaction = new Mock<IQueryTransaction>();
		var mapper = MapperFactory.Create<ListSavingQueryProfile>();
		queryHandler = new ListSavingQueryHandler(mockTransaction.Object, mapper);
	}

	[Test]
	public async Task WhenHandleAndDatabaseIsEmpty_ThenReturnsNoSavings()
	{
		var savings = new List<Saving>();

		mockTransaction.Setup(mock => mock.SavingRepository.ListAsync(It.IsAny<ISpecification<Saving>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(savings);

		var request = new ListSavingQuery
		{
			UserId = Guid.NewGuid()
		};

		var response = await queryHandler.Handle(request, CancellationToken.None);

		Assert.That(response.Savings, Is.Empty);

		mockTransaction.Verify(mock => mock.SavingRepository.ListAsync(It.IsAny<ISpecification<Saving>>(), It.IsAny<CancellationToken>()), Times.Once);
	}

	[Test]
	public async Task WhenHandleAndDatabaseIsNotEmpty_ThenReturnsSavingsForUser()
	{
		var userId = Guid.NewGuid();
		var savings = new List<Saving>
		{
			SavingFactory.Create(Guid.NewGuid(), 100, DateTime.Now.AddDays(-1), userId),
			SavingFactory.Create(Guid.NewGuid(), 400, DateTime.Now.AddDays(-2), userId)
		};

		mockTransaction.Setup(mock => mock.SavingRepository.ListAsync(It.IsAny<ISpecification<Saving>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(savings);

		var request = new ListSavingQuery
		{
			UserId = userId
		};

		var response = await queryHandler.Handle(request, CancellationToken.None);

		Assert.That(response.Savings, Has.Count.EqualTo(2));

		for (var index = 0; index < response.Savings.Count; ++index)
		{
			var expected = savings[index];
			var actual = response.Savings[index];

			Assert.Multiple(() =>
			{
				Assert.That(actual.SavingId, Is.EqualTo(expected.SavingId));
				Assert.That(actual.Amount, Is.EqualTo(expected.Amount));
				Assert.That(actual.DateTime, Is.EqualTo(expected.DateTime));
			});
		}

		mockTransaction.Verify(mock => mock.SavingRepository.ListAsync(It.IsAny<ISpecification<Saving>>(), It.IsAny<CancellationToken>()), Times.Once);
	}
}