namespace SeahawkSaverBackend.API.IntegrationTest.Utilities;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Utilities;
using SeahawkSaverBackend.Domain.Entities;
using SeahawkSaverBackend.Domain.Factories;

/**
 * <summary>
 * An in-memory collection of integration test database seed data.
 * </summary>
 */
public sealed class InMemoryIntegrationTestDatabaseDataset : IDatabaseDataset
{
	public IReadOnlyList<User> Users { get; }
	public IReadOnlyList<Debt> Debts { get; }
	public IReadOnlyList<Expense> Expenses { get; }
	public IReadOnlyList<Income> Incomes { get; }
	public IReadOnlyList<Saving> Savings { get; }
	public IReadOnlyList<Subscription> Subscriptions { get; }

	/**
	 * <summary>
	 * Instantiates a new <see cref="InMemoryIntegrationTestDatabaseDataset"/> instance.
	 * </summary>
	 */
	public InMemoryIntegrationTestDatabaseDataset()
	{
		var users = new List<User>
		{
			UserFactory.Create(Guid.Parse("E1E0B144-1DFF-4326-A4E1-6282A58D269B"),
							   "peter.keller@gmail.com",
							   "$2a$12$WQ01i3xqtxWUtOApynU3sOieWW38W1QW3yFaxQp0CdGq7dgE0.yji",
							   "Peter",
							   "Keller",
							   false,
							   true),

			UserFactory.Create(Guid.Parse("1567C912-FB83-4FF4-91B4-2232807837DB"),
							   "vicky.decker@yahoo.com",
							   "$2a$12$EjbEWwAE1Z3KbC7DnSAcB.OyuV3L0M5O0ikYM9Lrp1YlUXAEWPArO",
							   "Vicky",
							   "Decker",
							   false,
							   true),

			UserFactory.Create(Guid.Parse("F1B8EE24-D578-4733-95E0-0B627F343F96"),
							   "harold.shepard@gmail.com",
							   "$2a$12$AMeRQh0/NQbdkyi/C7rFTeDiWT6aitP2AtPnoui7lO3sDXjG6Q6GC",
							   "Harold",
							   "Shepard",
							   false,
							   true),

			UserFactory.Create(Guid.Parse("014F3DC5-C2F0-4E95-A44C-93E558006AED"),
							   "bert.simmons@outlook.com",
							   "$2a$12$58ke.sVs84.jSXDErQvskeP4isBsQFH57HVYO1xHwTi/RUA.wXzUK",
							   "Bert",
							   "Simmons",
							   false,
							   true),

			UserFactory.Create(Guid.Parse("613D4F63-ECC7-455E-A6EF-9DE724A579B7"),
							   "daisy.silva@gmail.com",
							   "$2a$12$D7EfVaB0mtraqqBS92MNuOZ2tUiemV/TSbXB7RU/rs.jdAGc3nOcO",
							   "Daisy",
							   "Silva",
							   false,
							   false),

			UserFactory.Create(Guid.Parse("531A2281-9058-41EB-B815-20D09ACE32FF"),
							   "russ.hendrix@gmail.com",
							   "$2a$12$UlRtKEGXKlz1YEPBGw70F.XcgsEa2zAvJS0QVmSYviWARIv3aCuci",
							   "Russ",
							   "Hendrix",
							   true,
							   true)
		};

		var debts = new List<Debt>();
		var expenses = new List<Expense>();

		var incomes = new List<Income>
		{
			IncomeFactory.Create(Guid.Parse("CC15E589-CE4D-419C-90F5-73B4181892FF"), 150, DateTime.Now.AddDays(-1), users[1].UserId),
			IncomeFactory.Create(Guid.Parse("CD382ABE-22AC-416D-A7AA-E3845EEA6964"), 50, DateTime.Now.AddDays(-2), users[1].UserId),
			IncomeFactory.Create(Guid.Parse("B627EC8E-F399-4561-974F-36838400EDAB"), 50, DateTime.Now.AddDays(-7), users[2].UserId),
			IncomeFactory.Create(Guid.Parse("AF2A303B-E01D-4F70-B00C-F880D3EF5862"), 75, DateTime.Now.AddDays(-8), users[2].UserId),
			IncomeFactory.Create(Guid.Parse("727923AD-D619-4ED8-A4F7-8DA3631558C2"), 25, DateTime.Now.AddDays(-9), users[2].UserId),
			IncomeFactory.Create(Guid.Parse("4B1B0C98-761C-4E67-AB7B-2FA67EF3A33E"), 100, DateTime.Now.AddDays(-10), users[2].UserId),
		};


		var savings = new List<Saving>
		{
			SavingFactory.Create(Guid.Parse("AF476108-6951-4246-BC4E-35EE0DB864E2"), 150, DateTime.Now.AddDays(-1), users[1].UserId),
			SavingFactory.Create(Guid.Parse("A8D2DC89-636B-4939-84C1-AA998F8BEDCA"), 50, DateTime.Now.AddDays(-2), users[1].UserId),
			SavingFactory.Create(Guid.Parse("11340AC3-CAAC-4967-B4B6-65A1D6E9402A"), 50, DateTime.Now.AddDays(-7), users[1].UserId),
			SavingFactory.Create(Guid.Parse("14B7AC98-EDB2-4063-8FD9-5D025D9A1680"), 75, DateTime.Now.AddDays(-8), users[1].UserId),
			SavingFactory.Create(Guid.Parse("F3D24C01-134D-4907-838B-7534A542990F"), 25, DateTime.Now.AddDays(-9), users[2].UserId),
			SavingFactory.Create(Guid.Parse("77A08D43-F746-47FB-973F-81F5849C17D5"), 100, DateTime.Now.AddDays(-10), users[2].UserId),
		};

		var subscriptions = new List<Subscription>();

		Users = users;
		Debts = debts;
		Expenses = expenses;
		Incomes = incomes;
		Savings = savings;
		Subscriptions = subscriptions;
	}
}