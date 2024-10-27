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
	public ListIncomeForUserIdSpecification(Guid userId)
	{
		Query.Where(income => income.UserId == userId);
	}
}