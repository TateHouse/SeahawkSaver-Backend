namespace SeahawkSaverBackend.Application.UnitTest.Features.Income.Queries.List;
using Ardalis.Specification;
using Moq;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Features.Income.Queries.List;
using SeahawkSaverBackend.Application.UnitTest.Utilities;
using SeahawkSaverBackend.Domain.Entities;
using SeahawkSaverBackend.Domain.Factories;

[TestFixture]
public sealed class ListIncomeQueryHandlerTest
{
	private Mock<IQueryTransaction> mockTransaction;
	private ListIncomeQueryHandler queryHandler;

	[SetUp]
	public void SetUp()
	{
		mockTransaction = new Mock<IQueryTransaction>();
		var mapper = MapperFactory.Create<ListIncomeQueryProfile>();
		queryHandler = new ListIncomeQueryHandler(mockTransaction.Object, mapper);
	}

	[Test]
	public async Task WHenHandleAndDatabaseIsEmpty_ThenReturnsNoIncome()
	{
		var incomes = new List<Income>();

		mockTransaction.Setup(mock => mock.IncomeRepository.ListAsync(It.IsAny<ISpecification<Income>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(incomes);

		var request = new ListIncomeQuery
		{
			UserId = Guid.NewGuid()
		};

		var response = await queryHandler.Handle(request, CancellationToken.None);

		Assert.That(response.Incomes, Is.Empty);

		mockTransaction.Verify(mock => mock.IncomeRepository.ListAsync(It.IsAny<ISpecification<Income>>(), It.IsAny<CancellationToken>()), Times.Once);
	}

	[Test]
	public async Task WhenHandleAndDatabaseIsNotEmpty_ThenReturnsIncomesForUser()
	{
		var userId = Guid.NewGuid();
		var incomes = new List<Income>
		{
			IncomeFactory.Create(Guid.NewGuid(), 100, DateTime.Now.AddDays(-1), userId),
			IncomeFactory.Create(Guid.NewGuid(), 400, DateTime.Now.AddDays(-2), userId)
		};

		mockTransaction.Setup(mock => mock.IncomeRepository.ListAsync(It.IsAny<ISpecification<Income>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(incomes);

		var request = new ListIncomeQuery
		{
			UserId = Guid.NewGuid()
		};

		var response = await queryHandler.Handle(request, CancellationToken.None);

		Assert.That(response.Incomes, Has.Count.EqualTo(2));

		for (var index = 0; index < response.Incomes.Count; ++index)
		{
			var expected = incomes[index];
			var actual = response.Incomes[index];

			Assert.Multiple(() =>
			{
				Assert.That(actual.IncomeId, Is.EqualTo(expected.IncomeId));
				Assert.That(actual.Amount, Is.EqualTo(expected.Amount));
				Assert.That(actual.DateTime, Is.EqualTo(expected.DateTime));
			});
		}

		mockTransaction.Verify(mock => mock.IncomeRepository.ListAsync(It.IsAny<ISpecification<Income>>(), It.IsAny<CancellationToken>()), Times.Once);
	}
}