namespace SeahawkSaverBackend.Application.Features.Subscription.Queries.Specifications;
using Ardalis.Specification;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * A specification for retrieving a <see cref="Subscription"/> entity from the database by its
 * <see cref="Subscription.SubscriptionId"/> and its associated <see cref="User.UserId"/>.
 * </summary>
 */
public sealed class GetSubscriptionByIdSpecification : SingleResultSpecification<Subscription>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="GetSubscriptionByIdSpecification"/> instance.
	 * </summary>
	 * <param name="subscriptionId">The subscription's id.</param>
	 * <param name="userId">The id of the associated user.</param>
	 */
	public GetSubscriptionByIdSpecification(Guid subscriptionId, Guid userId)
	{
		Query.Where(subscription => subscription.SubscriptionId == subscriptionId &&
									subscription.UserId == userId);
	}
}