namespace SeahawkSaverBackend.Application.Features.User.Queries.Specifications;
using Ardalis.Specification;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * A specification for retrieving a <see cref="User"/> by <see cref="User.Email"/>.
 * </summary>
 */
public sealed class GetUserByEmailSpecification : SingleResultSpecification<User>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="GetUserByEmailSpecification"/> instance.
	 * </summary>
	 * <param name="email">The user's email.</param>
	 */
	public GetUserByEmailSpecification(string email)
	{
		Query.Where(user => user.Email == email);
	}
}