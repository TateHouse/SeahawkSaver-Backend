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

	/**
	 * <summary>
	 * Instantiates a new <see cref="InMemoryDatabaseDataset"/> instance.
	 * </summary>
	 */
	public InMemoryDatabaseDataset()
	{
		var users = new List<User>
		{
			UserFactory.Create(Guid.Parse("2708359E-D074-4898-AD0A-FB59AF30CAF5"), "dan.bradley@gmail.com", "$2a$12$3VVlDojwK2r8lhM/ji3H1Otiihl1rJm213tqlXjZqb4QHVIlfJlgW"),
			UserFactory.Create(Guid.Parse("FBD0F688-78BA-45C9-BC9C-B14E8513754E"), "dixie.hale@yahoo.com", "$2a$12$16tc2LD/uGiBl43/HcEzJeHqGw2WEzZRHVJtuZBczsyWyV2hlMP1."),
			UserFactory.Create(Guid.Parse("6388ED01-58F8-4730-9E70-7A0305AE67F1"), "bethany.warren@gmail.com", "$2a$12$gwuxU25nRpSIqkzVwlLup.vzRjcntBnrKfbx3L7Z61UiNFzOUFSy."),
			UserFactory.Create(Guid.Parse("CA9E993C-D04A-4C53-8C32-9C6D5D59DA3A"), "herbert.elder@outlook.com", "$2a$12$M0s5IzE9EuPWeNj7pT4wU.VeKnkKH9depAC7JCxylZJ.IegRTTBEC")
		};

		Users = users;
	}
}