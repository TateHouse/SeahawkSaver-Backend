namespace SeahawkSaverBackend.Application.Abstractions.Persistence.Repositories;
using Ardalis.Specification;

/**
 * <summary>
 * An interface for a read-write entity repository.
 * </summary>
 * <typeparam name="TEntity">The type of the entity stored in the <see cref="IRepository{TEntity}"/>.</typeparam>
 */
public interface IRepository<TEntity> : IRepositoryBase<TEntity>
	where TEntity : class
{

}