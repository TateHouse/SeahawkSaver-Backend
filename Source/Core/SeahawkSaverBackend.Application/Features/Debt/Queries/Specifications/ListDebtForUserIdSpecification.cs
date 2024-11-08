namespace SeahawkSaverBackend.Application.Features.Debt.Queries.Specifications;
using Ardalis.Specification;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * A specification for retrieving all <see cref="Debt"/> entities from the database for a specific
 * <see cref="User"/>.
 * </summary>
 */
public sealed class ListDebtForUserIdSpecification : Specification<Debt>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ListDebtForUserIdSpecification"/> instance.
	 * </summary>
	 * <param name="userId">The user's id.</param>
	 */
	public ListDebtForUserIdSpecification(Guid userId)
	{
		Query.Where(debt => debt.UserId == userId);
	}
}