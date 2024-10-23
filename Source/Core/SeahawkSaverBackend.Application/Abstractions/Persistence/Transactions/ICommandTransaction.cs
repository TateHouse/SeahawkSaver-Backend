namespace SeahawkSaverBackend.Application.Abstractions.Persistence.Transactions;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Repositories;
using SeahawkSaverBackend.Domain.Entities;

public interface ICommandTransaction
{
	/**
	 * <summary>
	 * A read-write repository for <see cref="User"/> entities.
	 * </summary>
	 */
	public IRepository<User> UserRepository { get; }

	/**
	 * <summary>
	 * A value indicating whether the database transaction has started.
	 * </summary>
	 */
	public bool HasTransactionStarted { get; }

	/**
	 * <summary>
	 * Asynchronously saves all changes to the database.
	 * </summary>
	 * <returns>A task that represents the asynchronous operation, and it contains the number of state entries written
	 * to the database.</returns>
	 * <exception cref="DbUpdateException">An error is encountered while saving to the database.</exception>
	 * <exception cref="DbUpdateConcurrencyException">A concurrency violation is encountered while saving to the database.
	 * A concurrency violation occurs when an unexpected number of rows are affected during save. This is usually because
	 * the data in the database has been modified since it was loaded into memory.</exception>
	 * <exception cref="OperationCanceledException">If the <see cref="CancellationToken"/> is cancelled.</exception>
	 */
	public Task<int> SaveChangesAsync();

	/**
	 * <summary>
	 * Asynchronously begins the database transaction.
	 * </summary>
	 * <returns>A task that represents the asynchronous operation.</returns>
	 * <exception cref="OperationCanceledException">If the <see cref="CancellationToken"/> is cancelled.</exception>
	 */
	public Task BeginTransactionAsync();

	/**
	 * <summary>
	 * Asynchronously commits the database transaction.
	 * </summary>
	 * <returns>A task that represents the asynchronous operation.</returns>
	 * <exception cref="OperationCanceledException">If the <see cref="CancellationToken"/> is cancelled.</exception>
	 */
	public Task CommitTransactionAsync();

	/**
	 * <summary>
	 * Asynchronously discards changes made in the database transaction.
	 * </summary>
	 * <returns>A task that represents the asynchronous operation.</returns>
	 * <exception cref="OperationCanceledException">If the <see cref="CancellationToken"/> is cancelled.</exception>
	 */
	public Task RollbackTransactionAsync();
}