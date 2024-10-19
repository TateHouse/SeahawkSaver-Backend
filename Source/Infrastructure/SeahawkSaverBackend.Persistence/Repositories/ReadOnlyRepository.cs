namespace SeahawkSaverBackend.Persistence.Repositories;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Repositories;

/**
 * <summary>
 * A read-only entity repository.
 * </summary>
 */
public class ReadOnlyRepository<TEntity> : RepositoryBase<TEntity>, IReadOnlyRepository<TEntity>
	where TEntity : class
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ReadOnlyRepository{TEntity}"/> instance.
	 * </summary>
	 * <param name="databaseContext">The application's <see cref="Microsoft.EntityFrameworkCore.DbContext"/>.</param>
	 */
	public ReadOnlyRepository(DatabaseContext databaseContext)
		: base(databaseContext)
	{

	}

	/**
	 * <summary>
	 * Instantiates a new <see cref="ReadOnlyRepository{TEntity}"/> instance.
	 * </summary>
	 * <param name="databaseContext">The application's <see cref="Microsoft.EntityFrameworkCore.DbContext"/>.</param>
	 * <param name="specificationEvaluator">A specification evaluator.</param>
	 */
	public ReadOnlyRepository(DatabaseContext databaseContext, ISpecificationEvaluator specificationEvaluator)
		: base(databaseContext, specificationEvaluator)
	{

	}
}