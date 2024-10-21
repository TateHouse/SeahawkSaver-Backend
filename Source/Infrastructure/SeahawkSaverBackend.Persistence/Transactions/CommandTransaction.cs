namespace SeahawkSaverBackend.Persistence.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Repositories;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * The "unit of work" for commands.
 * </summary>
 */
public sealed class CommandTransaction : ICommandTransaction
{
	private readonly DatabaseContext databaseContext;
	private readonly bool isInMemoryDatabase;
	private IDbContextTransaction? transaction;

	public IRepository<User> UserRepository { get; }
	public bool HasTransactionStarted { get; private set; }

	/**
	 * <summary>
	 * Instantiates a new <see cref="CommandTransaction"/> instance.
	 * </summary>
	 * <param name="databaseContext">The application's <see cref="Microsoft.EntityFrameworkCore.DbContext"/>.</param>
	 * <param name="userRepository">A read-write repository for <see cref="User"/> entities.</param>
	 */
	public CommandTransaction(DatabaseContext databaseContext,
							  IRepository<User> userRepository)
	{
		this.databaseContext = databaseContext;
		isInMemoryDatabase = databaseContext.Database.IsInMemory();
		UserRepository = userRepository;
		HasTransactionStarted = false;
	}

	public async Task<int> SaveChangesAsync()
	{
		return await databaseContext.SaveChangesAsync();
	}

	public async Task BeginTransactionAsync()
	{
		HasTransactionStarted = true;

		if (isInMemoryDatabase)
		{
			return;
		}

		transaction = await databaseContext.Database.BeginTransactionAsync();
	}

	public async Task CommitTransactionAsync()
	{
		if (isInMemoryDatabase || transaction == null)
		{
			return;
		}

		await transaction.CommitAsync();
		await transaction.DisposeAsync();
		transaction = null;
		HasTransactionStarted = false;
	}

	public async Task RollbackTransactionAsync()
	{
		if (isInMemoryDatabase || transaction == null)
		{
			return;
		}

		await transaction.RollbackAsync();
		await transaction.DisposeAsync();
		transaction = null;
		HasTransactionStarted = false;
	}
}