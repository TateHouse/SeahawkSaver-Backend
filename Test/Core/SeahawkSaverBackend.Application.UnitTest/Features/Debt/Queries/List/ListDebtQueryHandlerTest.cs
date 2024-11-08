namespace SeahawkSaverBackend.Application.UnitTest.Features.Debt.Queries.List;
using Ardalis.Specification;
using Moq;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Features.Debt.Queries.List;
using SeahawkSaverBackend.Application.UnitTest.Utilities;
using SeahawkSaverBackend.Domain.Entities;
using SeahawkSaverBackend.Domain.Factories;

[TestFixture]
public sealed class ListDebtQueryHandlerTest
{
	private Mock<IQueryTransaction> mockTransaction;
	private ListDebtQueryHandler queryHandler;

	[SetUp]
	public void SetUp()
	{
		mockTransaction = new Mock<IQueryTransaction>();
		var mapper = MapperFactory.Create<ListDebtQueryProfile>();
		queryHandler = new ListDebtQueryHandler(mockTransaction.Object, mapper);
	}

	[Test]
	public async Task WHenHandleAndDatabaseIsEmpty_ThenReturnsNoDebt()
	{
		var debts = new List<Debt>();

		mockTransaction.Setup(mock => mock.DebtRepository.ListAsync(It.IsAny<ISpecification<Debt>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(debts);

		var request = new ListDebtQuery
		{
			UserId = Guid.NewGuid()
		};

		var response = await queryHandler.Handle(request, CancellationToken.None);

		Assert.That(response.Debts, Is.Empty);

		mockTransaction.Verify(mock => mock.DebtRepository.ListAsync(It.IsAny<ISpecification<Debt>>(), It.IsAny<CancellationToken>()), Times.Once);
	}

	[Test]
	public async Task WhenHandleAndDatabaseIsNotEmpty_ThenReturnsDebtsForUser()
	{
		var userId = Guid.NewGuid();
		var debts = new List<Debt>
		{
			DebtFactory.Create(Guid.NewGuid(), 100, DateTime.Now.AddDays(-1), userId),
			DebtFactory.Create(Guid.NewGuid(), 400, DateTime.Now.AddDays(-2), userId)
		};

		mockTransaction.Setup(mock => mock.DebtRepository.ListAsync(It.IsAny<ISpecification<Debt>>(), It.IsAny<CancellationToken>()))
					   .ReturnsAsync(debts);

		var request = new ListDebtQuery
		{
			UserId = Guid.NewGuid()
		};

		var response = await queryHandler.Handle(request, CancellationToken.None);

		Assert.That(response.Debts, Has.Count.EqualTo(2));

		for (var index = 0; index < response.Debts.Count; ++index)
		{
			var expected = debts[index];
			var actual = response.Debts[index];

			Assert.Multiple(() =>
			{
				Assert.That(actual.DebtId, Is.EqualTo(expected.DebtId));
				Assert.That(actual.Amount, Is.EqualTo(expected.Amount));
				Assert.That(actual.DateTime, Is.EqualTo(expected.DateTime));
			});
		}

		mockTransaction.Verify(mock => mock.DebtRepository.ListAsync(It.IsAny<ISpecification<Debt>>(), It.IsAny<CancellationToken>()), Times.Once);
	}
}