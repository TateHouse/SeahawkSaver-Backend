namespace SeahawkSaverBackend.Application.Features.Subscription.Queries.Specifications;
using Ardalis.Specification;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * A specification for retrieving all <see cref="Subscription"/> entities from the database for a specific
 * <see cref="User"/>.
 * </summary>
 */
public sealed class ListSubscriptionForUserIdSpecification : Specification<Subscription>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="ListSubscriptionForUserIdSpecification"/> instance.
	 * </summary>
	 * <param name="userId">The user's id.</param>
	 */
	public ListSubscriptionForUserIdSpecification(Guid userId)
	{
		Query.Where(subscription => subscription.UserId == userId);
	}
}