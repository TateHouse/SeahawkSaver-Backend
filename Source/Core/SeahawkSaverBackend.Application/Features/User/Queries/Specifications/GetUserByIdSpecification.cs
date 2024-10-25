namespace SeahawkSaverBackend.Application.Features.User.Queries.Specifications;
using Ardalis.Specification;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * A specification for retrieving a <see cref="User"/> by <see cref="User.UserId"/>.
 * </summary>
 */
public sealed class GetUserByIdSpecification : SingleResultSpecification<User>
{
	/**
	 * Instantiates a new <see cref="GetUserByIdSpecification"/> instance.
	 * <param name="userId">The user's id.</param>
	 */
	public GetUserByIdSpecification(Guid userId)
	{
		Query.Where(user => user.UserId == userId);
	}
}