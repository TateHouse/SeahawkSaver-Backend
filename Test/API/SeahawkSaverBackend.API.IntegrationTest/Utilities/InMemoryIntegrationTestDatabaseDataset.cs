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
							   "Keller"),

			UserFactory.Create(Guid.Parse("1567C912-FB83-4FF4-91B4-2232807837DB"),
							   "vicky.decker@yahoo.com",
							   "$2a$12$EjbEWwAE1Z3KbC7DnSAcB.OyuV3L0M5O0ikYM9Lrp1YlUXAEWPArO",
							   "Vicky",
							   "Decker"),

			UserFactory.Create(Guid.Parse("F1B8EE24-D578-4733-95E0-0B627F343F96"),
							   "harold.shepard@gmail.com",
							   "$2a$12$AMeRQh0/NQbdkyi/C7rFTeDiWT6aitP2AtPnoui7lO3sDXjG6Q6GC",
							   "Harold",
							   "Shepard"),

			UserFactory.Create(Guid.Parse("014F3DC5-C2F0-4E95-A44C-93E558006AED"),
							   "bert.simmons@outlook.com",
							   "$2a$12$58ke.sVs84.jSXDErQvskeP4isBsQFH57HVYO1xHwTi/RUA.wXzUK",
							   "Bert",
							   "Simmons"),
		};

		Users = users;
	}
}