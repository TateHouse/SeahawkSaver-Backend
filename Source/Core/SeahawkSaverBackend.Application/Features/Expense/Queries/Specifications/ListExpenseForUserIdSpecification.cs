namespace SeahawkSaverBackend.Application.Features.Expense.Queries.Specifications;
using Ardalis.Specification;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * A specification for retrieving all <see cref="Expense"/> entities from the database for a specific
 * <see cref="User"/>.
 * </summary>
 */
public sealed class ListExpenseForUserIdSpecification : Specification<Expense>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ListExpenseForUserIdSpecification"/> instance.
	 * </summary>
	 * <param name="userId">The user's id.</param>
	 */
	public ListExpenseForUserIdSpecification(Guid userId)
	{
		Query.Where(expense => expense.UserId == userId);
	}
}