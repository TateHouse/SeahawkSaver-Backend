namespace SeahawkSaverBackend.Application.Features.Income.Queries.Specifications;
using Ardalis.Specification;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * A specification for retrieving all <see cref="Income"/> entities from the database for a specific
 * <see cref="User"/>.
 * </summary>
 */
public sealed class ListIncomeForUserIdSpecification : Specification<Income>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ListIncomeForUserIdSpecification"/> instance.
	 * </summary>
	 * <param name="userId">The user's id.</param>
	 */
	public ListIncomeForUserIdSpecification(Guid userId)
	{
		Query.Where(income => income.UserId == userId);
	}
}