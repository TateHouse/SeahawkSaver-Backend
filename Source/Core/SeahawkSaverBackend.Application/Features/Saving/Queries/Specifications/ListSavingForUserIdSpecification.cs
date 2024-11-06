namespace SeahawkSaverBackend.Application.Features.Saving.Queries.Specifications;
using Ardalis.Specification;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * A specification for retrieving all <see cref="Saving"/> entities from the database for a specific
 * <see cref="User"/>.
 * </summary>
 */
public sealed class ListSavingForUserIdSpecification : Specification<Saving>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ListSavingForUserIdSpecification"/> instance.
	 * </summary>
	 * <param name="userId">The user's id.</param>
	 */
	public ListSavingForUserIdSpecification(Guid userId)
	{
		Query.Where(saving => saving.UserId == userId);
	}
}