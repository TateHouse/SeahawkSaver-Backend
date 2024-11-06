namespace SeahawkSaverBackend.Persistence.Utilities;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Utilities;
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
	public IReadOnlyList<Income> Incomes { get; }
	public IReadOnlyList<Saving> Savings { get; }

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
							   false),

			UserFactory.Create(Guid.Parse("FBD0F688-78BA-45C9-BC9C-B14E8513754E"),
							   "dixie.hale@yahoo.com",
							   "$2a$12$16tc2LD/uGiBl43/HcEzJeHqGw2WEzZRHVJtuZBczsyWyV2hlMP1.",
							   "Dixie",
							   "Hale",
							   false),

			UserFactory.Create(Guid.Parse("6388ED01-58F8-4730-9E70-7A0305AE67F1"),
							   "bethany.warren@gmail.com",
							   "$2a$12$gwuxU25nRpSIqkzVwlLup.vzRjcntBnrKfbx3L7Z61UiNFzOUFSy.",
							   "Bethany",
							   "Warren",
							   false),

			UserFactory.Create(Guid.Parse("CA9E993C-D04A-4C53-8C32-9C6D5D59DA3A"),
							   "herbert.elder@outlook.com",
							   "$2a$12$M0s5IzE9EuPWeNj7pT4wU.VeKnkKH9depAC7JCxylZJ.IegRTTBEC",
							   "Herbert",
							   "Elder",
							   false),

			UserFactory.Create(Guid.Parse("2E04419B-A15F-4DC2-9FDF-078E0BFC660A"),
							   "amy.peterson@gmail.com",
							   "$2a$12$Uy9DtGrt0STo50mBEisT1OUgesJ3vFSU4ZfnJZYQFiy43Aj9DKRCG",
							   "Amy",
							   "Peterson",
							   true)
		};

		var incomes = new List<Income>
		{
			IncomeFactory.Create(Guid.Parse("B279AFC1-D23D-4B37-96F4-73490F9431FC"), 100, DateTime.Now.AddDays(-1), users[1].UserId),
			IncomeFactory.Create(Guid.Parse("9827FF7C-4B19-4F39-AD28-4FAC43D5F72B"), 400, DateTime.Now.AddDays(-2), users[1].UserId),
			IncomeFactory.Create(Guid.Parse("1DF23E4F-9ADC-464F-9BB1-7804B6149638"), 250, DateTime.Now.AddDays(-7), users[2].UserId),
			IncomeFactory.Create(Guid.Parse("AF43BAF0-0217-4901-96CA-BD86C6092BF7"), 500, DateTime.Now.AddDays(-8), users[2].UserId),
			IncomeFactory.Create(Guid.Parse("E1803737-7CF8-4E3E-99C6-6C352E04AC35"), 750, DateTime.Now.AddDays(-9), users[2].UserId),
			IncomeFactory.Create(Guid.Parse("C5A244F1-5BFB-41B7-802B-302C4E7C4F5A"), 250, DateTime.Now.AddDays(-10), users[2].UserId),
			IncomeFactory.Create(Guid.Parse("38B2C309-42E9-4919-A639-A9FDA66C327E"), 150, DateTime.Now.AddDays(-1), users[2].UserId),
			IncomeFactory.Create(Guid.Parse("F991B7DA-7BE4-437A-B905-722C95A06819"), 8299, DateTime.Now.AddDays(-28), users[2].UserId),
			IncomeFactory.Create(Guid.Parse("CB4B8EB8-40F8-46A3-9687-4E59F3B81FF8"), 431, DateTime.Now.AddDays(-19), users[2].UserId),
			IncomeFactory.Create(Guid.Parse("53D15DD3-61E8-4519-AEF5-60A0546A1E23"), 293, DateTime.Now.AddDays(-10), users[2].UserId),
		};

		var savings = new List<Saving>
		{
			SavingFactory.Create(Guid.Parse("77DAB607-2797-440E-9C6E-5BDEC8D6C9D0"), 1000, DateTime.Now.AddDays(-1), users[1].UserId),
			SavingFactory.Create(Guid.Parse("5939B0EA-8D18-4AD1-825C-0019013DB55B"), 500, DateTime.Now.AddDays(-1), users[2].UserId),
			SavingFactory.Create(Guid.Parse("7D126146-146B-4D56-9210-36C7B9F348E7"), 850, DateTime.Now.AddDays(-1), users[2].UserId),
			SavingFactory.Create(Guid.Parse("F459605A-D4E2-4853-B9E6-C5A9B15BCA87"), 1250, DateTime.Now.AddDays(-1), users[2].UserId),
		};

		Users = users;
		Incomes = incomes;
		Savings = savings;
	}
}