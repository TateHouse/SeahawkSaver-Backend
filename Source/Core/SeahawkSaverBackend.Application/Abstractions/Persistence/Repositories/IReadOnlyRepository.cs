namespace SeahawkSaverBackend.Application.Abstractions.Persistence.Repositories;
using Ardalis.Specification;

/**
 * <summary>
 * An interface for a read-only entity repository.
 * </summary>
 * <typeparam name="TEntity">The type of the entity stored in the <see cref="IReadOnlyRepository{TEntity}"/>.</typeparam>
 */
public interface IReadOnlyRepository<TEntity> : IReadRepositoryBase<TEntity>
	where TEntity : class
{

}