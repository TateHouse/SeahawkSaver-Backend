namespace SeahawkSaverBackend.Persistence.Repositories;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using SeahawkSaverBackend.Application.Abstractions.Persistence.Repositories;

/**
 * <summary>
 * A read-write entity repository.
 * </summary>
 */
public class Repository<TEntity> : RepositoryBase<TEntity>, IRepository<TEntity>
	where TEntity : class
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="Repository{TEntity}"/> instance.
	 * </summary>
	 * <param name="databaseContext">The application's <see cref="Microsoft.EntityFrameworkCore.DbContext"/>.</param>
	 */
	public Repository(DatabaseContext databaseContext)
		: base(databaseContext)
	{

	}

	/**
	 * <summary>
	 * Instantiates a new <see cref="Repository{TEntity}"/> instance.
	 * </summary>
	 * <param name="databaseContext">The application's <see cref="Microsoft.EntityFrameworkCore.DbContext"/>.</param>
	 * <param name="specificationEvaluator">A specification evaluator.</param>
	 */
	public Repository(DatabaseContext databaseContext, ISpecificationEvaluator specificationEvaluator)
		: base(databaseContext, specificationEvaluator)
	{

	}
}