namespace SeahawkSaverBackend.Persistence.Utilities;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Utilities;
using SeahawkSaverBackend.Application.Utilities;
using SeahawkSaverBackend.Domain.Entities;
using SeahawkSaverBackend.Domain.Factories;

/**
 * <summary>
 * An in-memory collection of database seed data.
 * </summary>
 */
public sealed class InMemoryDatabaseDataset : IDatabaseDataset
{
	public IReadOnlyList<User> Users { get; }
	public IReadOnlyList<Debt> Debts { get; }
	public IReadOnlyList<Expense> Expenses { get; }
	public IReadOnlyList<Income> Incomes { get; }
	public IReadOnlyList<Saving> Savings { get; }
	public IReadOnlyList<Subscription> Subscriptions { get; }

	/**
	 * <summary>
	 * Instantiates a new <see cref="InMemoryDatabaseDataset"/> instance.
	 * </summary>
	 */
	public InMemoryDatabaseDataset()
	{
		var users = new List<User>
		{
			UserFactory.Create(Guid.Parse("2708359E-D074-4898-AD0A-FB59AF30CAF5"),
							   "dan.bradley@gmail.com",
							   "$2a$12$3VVlDojwK2r8lhM/ji3H1Otiihl1rJm213tqlXjZqb4QHVIlfJlgW",
							   "Dan",
							   "Bradley",
							   false,
							   true),

			UserFactory.Create(Guid.Parse("FBD0F688-78BA-45C9-BC9C-B14E8513754E"),
							   "dixie.hale@yahoo.com",
							   "$2a$12$16tc2LD/uGiBl43/HcEzJeHqGw2WEzZRHVJtuZBczsyWyV2hlMP1.",
							   "Dixie",
							   "Hale",
							   false,
							   true),

			UserFactory.Create(Guid.Parse("6388ED01-58F8-4730-9E70-7A0305AE67F1"),
							   "bethany.warren@gmail.com",
							   "$2a$12$gwuxU25nRpSIqkzVwlLup.vzRjcntBnrKfbx3L7Z61UiNFzOUFSy.",
							   "Bethany",
							   "Warren",
							   false,
							   true),

			UserFactory.Create(Guid.Parse("CA9E993C-D04A-4C53-8C32-9C6D5D59DA3A"),
							   "herbert.elder@outlook.com",
							   "$2a$12$M0s5IzE9EuPWeNj7pT4wU.VeKnkKH9depAC7JCxylZJ.IegRTTBEC",
							   "Herbert",
							   "Elder",
							   false,
							   true),

			UserFactory.Create(Guid.Parse("B90E7D1A-48A8-4417-9CA0-F404B3A6F983"),
							   "drew.dawson@gmail.com",
							   "$2a$12$xv0.y5u/hTBahDoEwA9FtunOrGUoWlG0dRDUpIi/97Gz1Qi2xFgwa",
							   "Drew",
							   "Dawson",
							   false,
							   false),

			UserFactory.Create(Guid.Parse("2E04419B-A15F-4DC2-9FDF-078E0BFC660A"),
							   "amy.peterson@gmail.com",
							   "$2a$12$Uy9DtGrt0STo50mBEisT1OUgesJ3vFSU4ZfnJZYQFiy43Aj9DKRCG",
							   "Amy",
							   "Peterson",
							   true,
							   true)
		};

		Users = users;
		Debts = GenerateDebts(users);
		Expenses = GenerateExpenses(users);
		Incomes = GenerateIncomes(users);
		Savings = GenerateSavings(users);
		Subscriptions = GenerateSubscriptions(users);
	}

	private static List<Debt> GenerateDebts(IReadOnlyList<User> users)
	{
		var debts = new List<Debt>();
		debts.AddRange(GenerateDebts(users[0].UserId));
		debts.AddRange(GenerateDebts(users[1].UserId));
		debts.AddRange(GenerateDebts(users[2].UserId));
		debts.AddRange(GenerateDebts(users[3].UserId));
		debts.AddRange(GenerateDebts(users[4].UserId));

		return debts;
	}

	private static List<Debt> GenerateDebts(Guid userId)
	{
		var entities = new List<Debt>();
		var random = new Random();

		for (var year = DateTime.Today.AddYears(-4).Year; year < 2025; ++year)
		{
			for (var month = 1; month <= 12; ++month)
			{
				var entityCount = random.Next(1, 2);
				var dateTimes = DateTimeUtilities.Generate(random, year, month, entityCount)
												 .ToList();

				for (var entityIndex = 0; entityIndex < entityCount; ++entityIndex)
				{
					var entity = DebtFactory.Create(Guid.NewGuid(),
													DecimalUtilities.Generate(random, 10.0, 2000.0),
													dateTimes[entityIndex],
													userId);

					entities.Add(entity);
				}
			}
		}

		return entities;
	}

	private static List<Expense> GenerateExpenses(IReadOnlyList<User> users)
	{
		var expenses = new List<Expense>();
		expenses.AddRange(GenerateExpenses(users[0].UserId));
		expenses.AddRange(GenerateExpenses(users[1].UserId));
		expenses.AddRange(GenerateExpenses(users[2].UserId));
		expenses.AddRange(GenerateExpenses(users[3].UserId));
		expenses.AddRange(GenerateExpenses(users[4].UserId));

		return expenses;
	}

	private static List<Expense> GenerateExpenses(Guid userId)
	{
		var entities = new List<Expense>();
		var random = new Random();

		for (var year = DateTime.Today.AddYears(-4).Year; year < 2025; ++year)
		{
			for (var month = 1; month <= 12; ++month)
			{
				var entityCount = random.Next(2, 20);
				var dateTimes = DateTimeUtilities.Generate(random, year, month, entityCount)
												 .ToList();

				for (var entityIndex = 0; entityIndex < entityCount; ++entityIndex)
				{
					var entity = ExpenseFactory.Create(Guid.NewGuid(),
													   DecimalUtilities.Generate(random, 5.0, 500.0),
													   dateTimes[entityIndex],
													   userId);

					entities.Add(entity);
				}
			}
		}

		return entities;
	}

	private static List<Income> GenerateIncomes(IReadOnlyList<User> users)
	{
		var incomes = new List<Income>();
		incomes.AddRange(GenerateIncomes(users[0].UserId));
		incomes.AddRange(GenerateIncomes(users[1].UserId));
		incomes.AddRange(GenerateIncomes(users[2].UserId));
		incomes.AddRange(GenerateIncomes(users[3].UserId));
		incomes.AddRange(GenerateIncomes(users[4].UserId));

		return incomes;
	}

	private static List<Income> GenerateIncomes(Guid userId)
	{
		var entities = new List<Income>();
		var random = new Random();

		for (var year = DateTime.Today.AddYears(-4).Year; year < 2025; ++year)
		{
			for (var month = 1; month <= 12; ++month)
			{
				var entityCount = random.Next(2, 4);
				var dateTimes = DateTimeUtilities.Generate(random, year, month, entityCount)
												 .ToList();

				for (var entityIndex = 0; entityIndex < entityCount; ++entityIndex)
				{
					var entity = IncomeFactory.Create(Guid.NewGuid(),
													  DecimalUtilities.Generate(random, 200.0, 2000.0),
													  dateTimes[entityIndex],
													  userId);

					entities.Add(entity);
				}
			}
		}

		return entities;
	}

	private static List<Saving> GenerateSavings(IReadOnlyList<User> users)
	{
		var savings = new List<Saving>();
		savings.AddRange(GenerateSavings(users[0].UserId));
		savings.AddRange(GenerateSavings(users[1].UserId));
		savings.AddRange(GenerateSavings(users[2].UserId));
		savings.AddRange(GenerateSavings(users[3].UserId));
		savings.AddRange(GenerateSavings(users[4].UserId));

		return savings;
	}

	private static List<Saving> GenerateSavings(Guid userId)
	{
		var entities = new List<Saving>();
		var random = new Random();

		for (var year = DateTime.Today.AddYears(-4).Year; year < 2025; ++year)
		{
			for (var month = 1; month <= 12; ++month)
			{
				var entityCount = random.Next(0, 2);
				var dateTimes = DateTimeUtilities.Generate(random, year, month, entityCount)
												 .ToList();

				for (var entityIndex = 0; entityIndex < entityCount; ++entityIndex)
				{
					var entity = SavingFactory.Create(Guid.NewGuid(),
													  DecimalUtilities.Generate(random, 100.0, 500.0),
													  dateTimes[entityIndex],
													  userId);

					entities.Add(entity);
				}
			}
		}

		return entities;
	}

	private static List<Subscription> GenerateSubscriptions(IReadOnlyList<User> users)
	{
		var subscriptions = new List<Subscription>();
		subscriptions.AddRange(GenerateSubscriptions(users[0].UserId));
		subscriptions.AddRange(GenerateSubscriptions(users[1].UserId));
		subscriptions.AddRange(GenerateSubscriptions(users[2].UserId));
		subscriptions.AddRange(GenerateSubscriptions(users[3].UserId));
		subscriptions.AddRange(GenerateSubscriptions(users[4].UserId));

		return subscriptions;
	}

	private static List<Subscription> GenerateSubscriptions(Guid userId)
	{
		var entities = new List<Subscription>();
		var random = new Random();
		var subscriptionAmounts = new List<decimal>
		{
			DecimalUtilities.Generate(random, 5.0, 50.0),
			DecimalUtilities.Generate(random, 5.0, 50.0),
			DecimalUtilities.Generate(random, 5.0, 50.0),
			DecimalUtilities.Generate(random, 5.0, 50.0),
		};

		for (var year = DateTime.Today.AddYears(-4).Year; year < 2025; ++year)
		{
			for (var month = 1; month <= 12; ++month)
			{
				var entityCount = random.Next(1, 4);
				var dateTimes = DateTimeUtilities.Generate(random, year, month, entityCount)
												 .ToList();

				for (var entityIndex = 0; entityIndex < entityCount; ++entityIndex)
				{
					var subscriptionAmountIndex = random.Next(0, 4);
					var entity = SubscriptionFactory.Create(Guid.NewGuid(),
															subscriptionAmounts[subscriptionAmountIndex],
															dateTimes[entityIndex],
															userId);

					entities.Add(entity);
				}
			}
		}

		return entities;
	}
}