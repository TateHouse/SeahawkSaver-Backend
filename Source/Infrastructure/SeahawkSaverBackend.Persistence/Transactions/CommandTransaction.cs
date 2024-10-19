namespace SeahawkSaverBackend.Persistence.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;

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

	public bool HasTransactionStarted { get; private set; }

	/**
	 * <summary>
	 * Instantiates a new <see cref="CommandTransaction"/> instance.
	 * </summary>
	 * <param name="databaseContext">The application's <see cref="Microsoft.EntityFrameworkCore.DbContext"/>.</param>
	 */
	public CommandTransaction(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
		isInMemoryDatabase = databaseContext.Database.IsInMemory();
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