namespace SeahawkSaverBackend.Application.Features.Saving.Queries.Specifications;
using Ardalis.Specification;
using SeahawkSaverBackend.Domain.Entities;

/**
 * <summary>
 * A specification for retrieving a <see cref="Saving"/> entity from the database by its <see cref="Saving.SavingId"/>
 * and its associated <see cref="User.UserId"/>.
 * </summary>
 */
public sealed class GetSavingByIdSpecification : SingleResultSpecification<Saving>
{
	/**
	 * <summary>
	 * Instantiates a new <see cref="GetSavingByIdSpecification"/> instance.
	 * </summary>
	 * <param name="savingId">The saving's id.</param>
	 * <param name="userId">The id of the associated user.</param>
	 */
	public GetSavingByIdSpecification(Guid savingId, Guid userId)
	{
		Query.Where(saving => saving.SavingId == savingId &&
							  saving.UserId == userId);
	}
}